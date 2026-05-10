using Rowles.LeanLucene.Codecs.DocValues;
using Rowles.LeanLucene.Codecs.StoredFields;
using Rowles.LeanLucene.Codecs.TermDictionary;
using Rowles.LeanLucene.Index.Format;
using Rowles.LeanLucene.Index.Segment;
using Rowles.LeanLucene.Store;

namespace Rowles.LeanLucene.Index.Migration;

/// <summary>
/// Plans and executes LeanLucene codec migrations.
/// </summary>
public static class IndexCodecMigrator
{
    private static readonly HashSet<string> ExecutableRewriteExtensions =
    [
        ".dic",
        ".dvn",
        ".dvs",
        ".fln",
        ".fdt",
        ".fdx"
    ];

    /// <summary>
    /// Builds a deterministic codec migration plan for <paramref name="directory"/>.
    /// </summary>
    /// <param name="directory">The index directory.</param>
    /// <param name="options">Migration options.</param>
    /// <returns>The migration plan.</returns>
    public static IndexCodecMigrationPlan Plan(MMapDirectory directory, IndexCodecMigrationOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(directory);
        options ??= new IndexCodecMigrationOptions();

        var inventory = IndexFormatInspector.Inspect(directory);
        var actions = new List<IndexCodecMigrationAction>();
        AddActions(inventory.Segments.SelectMany(static segment => segment.Files), actions);
        AddActions(inventory.OrphanFiles, actions);

        return new IndexCodecMigrationPlan
        {
            Inventory = inventory,
            Actions = actions,
            CanExecute = actions.All(static action => action.CanExecute),
            Issues = inventory.Issues
        };
    }

    /// <summary>
    /// Runs a codec migration or returns the dry-run plan when <see cref="IndexCodecMigrationOptions.DryRun"/> is <c>true</c>.
    /// </summary>
    /// <param name="directory">The index directory.</param>
    /// <param name="options">Migration options.</param>
    /// <returns>The migration result.</returns>
    public static IndexCodecMigrationResult Migrate(MMapDirectory directory, IndexCodecMigrationOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(directory);
        options ??= new IndexCodecMigrationOptions();

        var plan = Plan(directory, options);
        if (options.DryRun)
        {
            return new IndexCodecMigrationResult
            {
                Succeeded = plan.CanExecute,
                DryRun = true,
                SourceDirectory = directory.DirectoryPath,
                StagingDirectory = options.StagingDirectory,
                ExecutedActions = plan.Actions,
                ValidationResult = null,
                Issues = plan.Issues
            };
        }

        if (plan.Actions.Count == 0)
        {
            return new IndexCodecMigrationResult
            {
                Succeeded = true,
                DryRun = false,
                SourceDirectory = directory.DirectoryPath,
                StagingDirectory = options.StagingDirectory,
                ExecutedActions = [],
                ValidationResult = null,
                Issues = plan.Issues
            };
        }

        if (!plan.CanExecute)
        {
            var unsupportedIssues = new List<IndexCheckIssue>(plan.Issues);
            foreach (var action in plan.Actions.Where(static action => !action.CanExecute))
            {
                unsupportedIssues.Add(new IndexCheckIssue
                {
                    Severity = IndexCheckSeverity.Error,
                    Code = IndexCheckIssueCodes.UnsupportedMigrationPath,
                    Message = action.ReasonCannotExecute ?? $"Migration action for '{action.SourcePath}' is not executable.",
                    FileName = action.FileName,
                    SegmentId = action.SegmentId,
                    IsRepairable = false
                });
            }

            return new IndexCodecMigrationResult
            {
                Succeeded = false,
                DryRun = false,
                SourceDirectory = directory.DirectoryPath,
                StagingDirectory = options.StagingDirectory,
                ExecutedActions = [],
                ValidationResult = null,
                Issues = unsupportedIssues
            };
        }

        if (options.ValidateBeforeMigration)
        {
            var validation = IndexValidator.Check(directory, new IndexCheckOptions { Deep = true });
            if (HasErrors(validation))
            {
                return new IndexCodecMigrationResult
                {
                    Succeeded = false,
                    DryRun = false,
                    SourceDirectory = directory.DirectoryPath,
                    StagingDirectory = options.StagingDirectory,
                    ExecutedActions = [],
                    ValidationResult = validation,
                    Issues = validation.DetailedIssues
                };
            }
        }

        var sourceDirectory = directory.DirectoryPath;
        var useStaging = options.UseStagingDirectory || !options.AllowInPlaceMigration;
        var targetDirectory = useStaging
            ? ResolveStagingDirectory(sourceDirectory, options.StagingDirectory)
            : sourceDirectory;
        var now = DateTimeOffset.UtcNow;
        var marker = new IndexMigrationMarker
        {
            State = useStaging ? IndexMigrationState.Prepared : IndexMigrationState.InProgress,
            SourceDirectory = sourceDirectory,
            StagingDirectory = targetDirectory,
            SourceCommitGeneration = plan.Inventory.CommitGeneration,
            CreatedAtUtc = now,
            UpdatedAtUtc = now,
            PlannedActions = plan.Actions
        };

        var executed = new List<IndexCodecMigrationAction>();
        var currentState = marker.State;
        try
        {
            IndexMigrationRecovery.WriteMarker(sourceDirectory, marker, durable: true);
            if (useStaging)
            {
                PrepareStagingDirectory(sourceDirectory, targetDirectory);
                IndexMigrationRecovery.WriteMarker(
                    sourceDirectory,
                    marker with { State = IndexMigrationState.InProgress, UpdatedAtUtc = DateTimeOffset.UtcNow },
                    durable: true);
                currentState = IndexMigrationState.InProgress;
            }

            var rewrittenStoredFieldSegments = new HashSet<string>(StringComparer.Ordinal);
            foreach (var action in plan.Actions)
            {
                ExecuteRewrite(targetDirectory, action, rewrittenStoredFieldSegments);
                executed.Add(action);
            }

            IndexCheckResult? validationResult = null;
            if (options.ValidateAfterMigration)
            {
                using var target = new MMapDirectory(targetDirectory);
                validationResult = IndexValidator.Check(target, new IndexCheckOptions { Deep = true });
                if (HasErrors(validationResult))
                {
                    IndexMigrationRecovery.WriteMarker(
                        sourceDirectory,
                        marker with { State = IndexMigrationState.Failed, UpdatedAtUtc = DateTimeOffset.UtcNow },
                        durable: true);
                    return new IndexCodecMigrationResult
                    {
                        Succeeded = false,
                        DryRun = false,
                        SourceDirectory = sourceDirectory,
                        StagingDirectory = useStaging ? targetDirectory : null,
                        ExecutedActions = executed,
                        ValidationResult = validationResult,
                        Issues = validationResult.DetailedIssues
                    };
                }
            }

            if (useStaging)
            {
                IndexMigrationRecovery.WriteMarker(
                    sourceDirectory,
                    marker with { State = IndexMigrationState.ReadyToPublish, UpdatedAtUtc = DateTimeOffset.UtcNow },
                    durable: true);
                currentState = IndexMigrationState.ReadyToPublish;
                PublishStagingDirectory(sourceDirectory, targetDirectory);
            }

            IndexMigrationRecovery.WriteMarker(
                sourceDirectory,
                marker with { State = IndexMigrationState.Published, UpdatedAtUtc = DateTimeOffset.UtcNow },
                durable: true);
            currentState = IndexMigrationState.Published;

            return new IndexCodecMigrationResult
            {
                Succeeded = true,
                DryRun = false,
                SourceDirectory = sourceDirectory,
                StagingDirectory = useStaging ? targetDirectory : null,
                ExecutedActions = executed,
                ValidationResult = validationResult,
                Issues = plan.Issues
            };
        }
        catch (Exception ex) when (ex is IOException or InvalidDataException or UnauthorizedAccessException)
        {
            if (currentState != IndexMigrationState.ReadyToPublish)
            {
                IndexMigrationRecovery.WriteMarker(
                    sourceDirectory,
                    marker with { State = IndexMigrationState.Failed, UpdatedAtUtc = DateTimeOffset.UtcNow },
                    durable: true);
            }

            var issues = new List<IndexCheckIssue>(plan.Issues)
            {
                new()
                {
                    Severity = IndexCheckSeverity.Error,
                    Code = IndexCheckIssueCodes.UnsupportedMigrationPath,
                    Message = ex.Message,
                    IsRepairable = true
                }
            };

            return new IndexCodecMigrationResult
            {
                Succeeded = false,
                DryRun = false,
                SourceDirectory = sourceDirectory,
                StagingDirectory = useStaging ? targetDirectory : null,
                ExecutedActions = executed,
                ValidationResult = null,
                Issues = issues
            };
        }
    }

    private static bool HasErrors(IndexCheckResult result)
        => result.DetailedIssues.Any(static issue => issue.Severity == IndexCheckSeverity.Error);

    private static string ResolveStagingDirectory(string sourceDirectory, string? requestedStagingDirectory)
    {
        if (!string.IsNullOrWhiteSpace(requestedStagingDirectory))
            return Path.GetFullPath(requestedStagingDirectory);

        var parent = Directory.GetParent(sourceDirectory)?.FullName ?? Path.GetFullPath(sourceDirectory);
        var directoryName = Path.GetFileName(Path.TrimEndingDirectorySeparator(sourceDirectory));
        return Path.Combine(parent, $"{directoryName}.migration-{Guid.NewGuid():N}");
    }

    private static void PrepareStagingDirectory(string sourceDirectory, string stagingDirectory)
    {
        if (Directory.Exists(stagingDirectory))
            throw new IOException($"Staging directory '{stagingDirectory}' already exists.");

        Directory.CreateDirectory(stagingDirectory);
        foreach (var file in Directory.EnumerateFiles(sourceDirectory))
        {
            var name = Path.GetFileName(file);
            if (string.Equals(name, "write.lock", StringComparison.Ordinal) ||
                string.Equals(name, IndexMigrationRecovery.MarkerFileName, StringComparison.Ordinal))
            {
                continue;
            }

            File.Copy(file, Path.Combine(stagingDirectory, name), overwrite: false);
        }
    }

    private static void PublishStagingDirectory(string sourceDirectory, string stagingDirectory)
    {
        foreach (var file in Directory.EnumerateFiles(stagingDirectory))
        {
            var name = Path.GetFileName(file);
            if (string.Equals(name, IndexMigrationRecovery.MarkerFileName, StringComparison.Ordinal))
                continue;

            File.Copy(file, Path.Combine(sourceDirectory, name), overwrite: true);
        }
    }

    private static void ExecuteRewrite(
        string targetDirectory,
        IndexCodecMigrationAction action,
        HashSet<string> rewrittenStoredFieldSegments)
    {
        if (action.Kind != IndexCodecMigrationActionKind.RewriteFile)
            return;

        var filePath = Path.Combine(targetDirectory, action.SourcePath);
        switch (Path.GetExtension(action.SourcePath))
        {
            case ".dic":
                RewriteTermDictionary(filePath);
                break;
            case ".dvn":
                RewriteNumericDocValues(filePath);
                break;
            case ".dvs":
                RewriteSortedDocValues(filePath);
                break;
            case ".fln":
                RewriteFieldLengths(filePath);
                break;
            case ".fdt":
            case ".fdx":
                if (action.SegmentId is not null && !rewrittenStoredFieldSegments.Add(action.SegmentId))
                    return;
                RewriteStoredFields(targetDirectory, action);
                break;
            default:
                throw new InvalidDataException($"No migration writer is registered for '{action.SourcePath}'.");
        }
    }

    private static void RewriteTermDictionary(string path)
    {
        using var reader = TermDictionaryReader.Open(path);
        var terms = reader.EnumerateAllTerms();
        TermDictionaryWriter.Write(
            path,
            terms.Select(static term => term.Term).ToList(),
            terms.ToDictionary(static term => term.Term, static term => term.Offset, StringComparer.Ordinal));
    }

    private static void RewriteNumericDocValues(string path)
    {
        var (values, presence) = NumericDocValuesReader.Read(path);
        var docCount = values.Count == 0 ? 0 : values.Values.Max(static field => field.Length);
        var presenceSets = new Dictionary<string, IReadOnlySet<int>>(StringComparer.Ordinal);
        foreach (var (field, bitmap) in presence)
        {
            if (bitmap is not null)
                presenceSets[field] = bitmap.ToHashSet();
        }

        NumericDocValuesWriter.Write(path, values, docCount, presenceSets);
    }

    private static void RewriteSortedDocValues(string path)
    {
        var (values, _) = SortedDocValuesReader.Read(path);
        var docCount = values.Count == 0 ? 0 : values.Values.Max(static field => field.Length);
        var nullableValues = values.ToDictionary(
            static item => item.Key,
            static item => item.Value.Select(static value => (string?)value).ToArray(),
            StringComparer.Ordinal);
        SortedDocValuesWriter.Write(path, nullableValues, docCount);
    }

    private static void RewriteFieldLengths(string path)
    {
        var values = FieldLengthReader.TryRead(path) ?? new Dictionary<string, int[]>(StringComparer.Ordinal);
        var docCount = values.Count == 0 ? 0 : values.Values.Max(static field => field.Length);
        FieldLengthWriter.Write(path, values, docCount);
    }

    private static void RewriteStoredFields(string targetDirectory, IndexCodecMigrationAction action)
    {
        if (action.SegmentId is null)
            throw new InvalidDataException($"Stored fields action for '{action.SourcePath}' has no segment ID.");

        var basePath = Path.Combine(targetDirectory, action.SegmentId);
        var info = SegmentInfo.ReadFrom(basePath + ".seg");
        using var reader = StoredFieldsReader.Open(basePath + ".fdt", basePath + ".fdx");
        StoredFieldsWriter.Write(
            basePath + ".fdt",
            basePath + ".fdx",
            info.DocCount,
            reader.ReadDocument,
            compression: FieldCompressionPolicy.Brotli);
    }

    private static void AddActions(IEnumerable<CodecFileInventory> files, List<IndexCodecMigrationAction> actions)
    {
        foreach (var file in files)
        {
            if (file.Version is null ||
                file.CurrentVersion is null ||
                file.IsCurrent ||
                !file.HasValidMagic ||
                !file.IsSupported)
            {
                continue;
            }

            bool canExecute = ExecutableRewriteExtensions.Contains(file.Extension);
            actions.Add(new IndexCodecMigrationAction
            {
                Kind = IndexCodecMigrationActionKind.RewriteFile,
                SourcePath = file.FileName,
                TargetPath = null,
                Description = $"Rewrite {file.FileName} from {file.CodecName} v{file.Version} to v{file.CurrentVersion}.",
                CanExecute = canExecute,
                ReasonCannotExecute = canExecute ? null : $"No migration writer is registered for {file.CodecName}.",
                SegmentId = file.SegmentId,
                FileName = file.FileName,
                FromVersion = file.Version,
                ToVersion = file.CurrentVersion
            });
        }
    }
}

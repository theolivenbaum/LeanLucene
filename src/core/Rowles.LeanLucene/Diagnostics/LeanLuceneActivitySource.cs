using System.Diagnostics;

namespace Rowles.LeanLucene.Diagnostics;

/// <summary>
/// Shared <see cref="ActivitySource"/> for LeanLucene instrumentation.
/// Activities are only allocated when a listener is attached — zero overhead otherwise.
/// </summary>
internal static class LeanLuceneActivitySource
{
    internal static readonly ActivitySource Source = new("Rowles.LeanLucene");

    internal const string Search = "leanlucene.search";
    internal const string Commit = "leanlucene.index.commit";
    internal const string Flush = "leanlucene.index.flush";
    internal const string Merge = "leanlucene.index.merge";
    internal const string FormatInspect = "leanlucene.index.format.inspect";
    internal const string CodecMigrationPlan = "leanlucene.index.codec_migration.plan";
    internal const string CodecMigrationMigrate = "leanlucene.index.codec_migration.migrate";
    internal const string BackupManifest = "leanlucene.index.backup.manifest";
    internal const string BackupCopy = "leanlucene.index.backup.copy";
    internal const string BackupValidate = "leanlucene.index.backup.validate";
    internal const string BackupRestore = "leanlucene.index.backup.restore";
}

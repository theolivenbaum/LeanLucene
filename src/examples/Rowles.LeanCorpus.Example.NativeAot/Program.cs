using System.Linq;
using Rowles.LeanCorpus.Codecs.StoredFields;
using Rowles.LeanCorpus.Diagnostics;
using Rowles.LeanCorpus.Document;
using Rowles.LeanCorpus.Document.Fields;
using Rowles.LeanCorpus.Index.Indexer;
using Rowles.LeanCorpus.Search.Geo;
using Rowles.LeanCorpus.Search.Queries;
using Rowles.LeanCorpus.Search.Scoring;
using Rowles.LeanCorpus.Search.Searcher;
using Rowles.LeanCorpus.Linq;
using Rowles.LeanCorpus.Mapping;
using Rowles.LeanCorpus.Store;

var rootPath = Path.Combine(Path.GetTempPath(), "leancorpus-aot-smoke-" + Guid.NewGuid().ToString("N"));

try
{
    RunPolicy(FieldCompressionPolicy.None, rootPath);
    RunPolicy(FieldCompressionPolicy.Deflate, rootPath);
    RunPolicy(FieldCompressionPolicy.Brotli, rootPath);

    Directory.Delete(rootPath, recursive: true);
    Console.WriteLine("LeanCorpus Native AOT smoke passed.");
    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine(ex);
    return 1;
}

static void RunPolicy(FieldCompressionPolicy policy, string rootPath)
{
    var indexPath = Path.Combine(rootPath, policy.ToString());

    try
    {
        Directory.CreateDirectory(indexPath);
        using var directory = new MMapDirectory(indexPath);

        using (var writer = new IndexWriter(directory, new IndexWriterConfig
        {
            CompressionPolicy = policy,
            MaxBufferedDocs = 2,
            RamBufferSizeMB = 1,
        }))
        {
            foreach (var document in BuildDocuments())
                writer.AddDocument(document);
            writer.Commit();
        }

        var analyticsPath = Path.Combine(indexPath, "search-analytics.json");
        var slowLogPath = Path.Combine(indexPath, "slow-queries.jsonl");
        var analytics = new SearchAnalytics(capacity: 32);

        using (var slowLog = SlowQueryLog.ToFile(thresholdMs: 0, slowLogPath))
        {
            using var searcher = new IndexSearcher(directory, new IndexSearcherConfig
            {
                SearchAnalytics = analytics,
                SlowQueryLog = slowLog,
            });

            AssertHits(searcher.Search(new TermQuery("status", "active"), 10), 3, "term query");
            AssertHits(searcher.Search(new PhraseQuery("title", "native", "aot"), 10), 1, "phrase query");
            AssertHits(searcher.Search(new PrefixQuery("title", "nat"), 10), 1, "prefix query");
            AssertHits(searcher.Search(new RegexpQuery("code", "^nat"), 10), 1, "regexp query");
            AssertHits(searcher.Search(new RangeQuery("year", 2024, 2026), 10), 2, "numeric range query");
            AssertHits(searcher.Search(new GeoDistanceQuery("location", 51.5074, -0.1278, 250_000), 10), 2, "geo distance query");
            AssertHits(searcher.Search(new GeoBoundingBoxQuery("location", 51.0, 52.0, -3.0, 0.5), 10), 2, "geo bounding-box query");
            var vectorResults = searcher.Search(new VectorQuery("embedding", [1f, 0f, 0f, 0f], topK: 2), 2);
            Assert(vectorResults.ScoreDocs.Length == 2, $"vector query returned {vectorResults.ScoreDocs.Length} scored document(s), expected 2.");

            var collapsed = searcher.SearchWithCollapse(new TermQuery("status", "active"), 10, new CollapseField("category"));
            Assert(collapsed.TotalHits == 2, $"collapsed search returned {collapsed.TotalHits} group(s), expected 2.");

            var storedResult = searcher.Search(new TermQuery("id", "doc-1"), 1);
            AssertHits(storedResult, 1, "stored-field lookup");
            var stored = searcher.GetStoredFields(storedResult.ScoreDocs[0].DocId);
            Assert(stored.TryGetValue("title", out var title) && title.Contains("native aot search"),
                "stored field 'title' was not readable after reopening the index.");
            Assert(stored.TryGetValue("location", out var location) && location.Contains("51.5074,-0.1278"),
                "stored geo field was not readable after reopening the index.");

            // LINQ queryable smoke — comprehensive AOT coverage.
            var resolver = (string name) => name switch
            {
                "Title"       => (IFieldDescriptor?)NativeSmokeFields.Title,
                "Year"        => NativeSmokeFields.Year,
                "Status"      => NativeSmokeFields.Status,
                "IsPublished" => NativeSmokeFields.IsPublished,
                _ => null,
            };
            var map = new NativeSmokeDocMap();
            var queryable = map.AsQueryable(searcher, resolver);

            // Where + compound &&.
            var whereAnd = queryable.Where(d => d.Status == "active" && d.Year > 2023).ToList();
            Assert(whereAnd.Count == 2, $"Where && returned {whereAnd.Count}, expected 2.");

            // Where + ||.
            var whereOr = queryable.Where(d => d.Status == "archived" || d.Status == "active").ToList();
            Assert(whereOr.Count == 4, $"Where || returned {whereOr.Count}, expected 4.");

            // First / FirstOrDefault.
            var first = queryable.Where(d => d.Status == "archived").First();
            Assert(first.Year == 2020, $"First returned year {first.Year}, expected 2020.");
            var firstDef = queryable.Where(d => d.Status == "nonexistent").FirstOrDefault();
            Assert(firstDef is null, "FirstOrDefault should return null for empty results.");

            // Single / SingleOrDefault.
            var single = queryable.Where(d => d.Status == "archived").Single();
            Assert(single.Year == 2020, $"Single returned year {single.Year}, expected 2020.");
            var singleDef = queryable.Where(d => d.Status == "nonexistent").SingleOrDefault();
            Assert(singleDef is null, "SingleOrDefault should return null for empty results.");

            // Count / Any.
            var count = queryable.Where(d => d.Status == "active").Count();
            Assert(count == 3, $"Count returned {count}, expected 3.");
            var countAll = queryable.Count();
            Assert(countAll == 4, $"Count (all) returned {countAll}, expected 4.");
            Assert(queryable.Where(d => d.Status == "active").Any(), "Any should return true.");
            Assert(!queryable.Where(d => d.Status == "nonexistent").Any(), "Any should return false for no matches.");

            // Take / Skip.
            var take = queryable.Where(d => d.Status == "active").Take(2).ToList();
            Assert(take.Count == 2, $"Take(2) returned {take.Count}, expected 2.");
            var skip = queryable.Where(d => d.Status == "active").Skip(1).ToList();
            Assert(skip.Count == 2, $"Skip(1) returned {skip.Count}, expected 2.");

            // Select projection.
            var titles = queryable
                .Where(d => d.Year >= 2024)
                .Select(d => d.Title)
                .ToList();
            Assert(titles.Count == 2, $"Select projection returned {titles.Count}, expected 2.");

            // Select + Take (projected queryable with Take terminal).
            var projectedTake = queryable
                .Where(d => d.Status == "active")
                .Select(d => d.Title)
                .Take(1)
                .ToList();
            Assert(projectedTake.Count == 1, $"Select+Take returned {projectedTake.Count}, expected 1.");

            // Select + Skip (projected queryable with Skip terminal).
            var projectedSkip = queryable
                .Where(d => d.Status == "active")
                .Select(d => d.Title)
                .Skip(1)
                .ToList();
            Assert(projectedSkip.Count == 2, $"Select+Skip returned {projectedSkip.Count}, expected 2.");

            // Boolean member predicate (standalone IsPublished).
            var published = queryable.Where(d => d.IsPublished).ToList();
            Assert(published.Count == 4, $"IsPublished returned {published.Count}, expected 4 (all default true).");

            // string.StartsWith / string.EndsWith.
            var starts = queryable.Where(d => d.Title!.StartsWith("native")).ToList();
            Assert(starts.Count == 1, $"StartsWith returned {starts.Count}, expected 1.");
            var ends = queryable.Where(d => d.Title!.EndsWith("indexing")).ToList();
            Assert(ends.Count == 1, $"EndsWith returned {ends.Count}, expected 1.");

            // Fix #1: captured IQueryable variable preserves predicates.
            var captured = queryable.Where(d => d.Status == "active");
            var recaptured = captured.Where(d => d.Year > 2023).ToList();
            Assert(recaptured.Count == 2, $"Captured+Where returned {recaptured.Count}, expected 2.");

            // Fix #2: OrderBy / OrderByDescending.
            var ordered = queryable.Where(d => d.Status == "active").OrderBy(d => d.Year).ToList();
            Assert(ordered.Count == 3, $"OrderBy returned {ordered.Count}, expected 3.");
            Assert(ordered[0].Year == 2023, $"OrderBy first year {ordered[0].Year}, expected 2023.");
            Assert(ordered[2].Year == 2025, $"OrderBy last year {ordered[2].Year}, expected 2025.");
            var orderedDesc = queryable.Where(d => d.Status == "active").OrderByDescending(d => d.Year).ToList();
            Assert(orderedDesc[0].Year == 2025, $"OrderByDesc first year {orderedDesc[0].Year}, expected 2025.");

            // Fix #12: ids.Contains(d.Field) → TermInSetQuery.
            var statuses = new[] { "active", "archived" };
            var inSet = queryable.Where(d => statuses.Contains(d.Status!)).ToList();
            Assert(inSet.Count == 4, $"TermInSet returned {inSet.Count}, expected 4.");

            // Fix #16: .Where() after .Select() on original doc type (not projected filter).
            // Post-projection filtering (e.g. .Select().Where(t => t.StartsWith(...)))
            // is not yet supported — it requires in-memory filtering after materialisation.
            var projectedThenWhere = queryable
                .Where(d => d.Title!.StartsWith("native"))
                .Select(d => d.Title)
                .ToList();
            Assert(projectedThenWhere.Count == 1, $"Where+Select returned {projectedThenWhere.Count}, expected 1.");
        }

        using (var analyticsWriter = File.CreateText(analyticsPath))
            analytics.ExportJson(analyticsWriter);

        Assert(new FileInfo(analyticsPath).Length > 2, "search analytics JSON was not written.");
        Assert(new FileInfo(slowLogPath).Length > 0, "slow-query log was not written.");
    }
    catch (Exception ex)
    {
        throw new InvalidOperationException($"Native AOT smoke failed for index directory '{indexPath}'.", ex);
    }
}

static LeanDocument[] BuildDocuments()
{
    return
    [
        Document(
            id: "doc-1",
            title: "native aot search",
            body: "lean corpus supports compact native publishing",
            code: "native",
            status: "active",
            category: "docs",
            year: 2025,
            latitude: 51.5074,
            longitude: -0.1278,
            embedding: [1f, 0f, 0f, 0f]),
        Document(
            id: "doc-2",
            title: "fast corpus indexing",
            body: "stored fields and diagnostics stay available",
            code: "index",
            status: "active",
            category: "docs",
            year: 2024,
            latitude: 51.4545,
            longitude: -2.5879,
            embedding: [0.9f, 0.1f, 0f, 0f]),
        Document(
            id: "doc-3",
            title: "api filtering",
            body: "geo vector and collapse queries are covered",
            code: "api",
            status: "active",
            category: "api",
            year: 2023,
            latitude: 40.7128,
            longitude: -74.0060,
            embedding: [0f, 1f, 0f, 0f]),
        Document(
            id: "doc-4",
            title: "archived sample",
            body: "inactive documents remain searchable by explicit status",
            code: "archive",
            status: "archived",
            category: "archive",
            year: 2020,
            latitude: 48.8566,
            longitude: 2.3522,
            embedding: [0f, 0f, 1f, 0f]),
    ];
}

static LeanDocument Document(
    string id,
    string title,
    string body,
    string code,
    string status,
    string category,
    int year,
    double latitude,
    double longitude,
    float[] embedding,
    bool isPublished = true)
{
    var document = new LeanDocument();
    document.Add(new StringField("id", id));
    document.Add(new TextField("title", title));
    document.Add(new TextField("body", body));
    document.Add(new StringField("code", code));
    document.Add(new StringField("status", status));
    document.Add(new StringField("category", category));
    document.Add(new NumericField("year", year));
    document.Add(new GeoPointField("location", latitude, longitude));
    document.Add(new VectorField("embedding", new ReadOnlyMemory<float>(embedding)));
    document.Add(new StringField("isPublished", isPublished ? "true" : "false", stored: true));
    return document;
}

static void AssertHits(TopDocs results, int expectedHits, string scenario)
    => Assert(results.TotalHits == expectedHits, $"{scenario} returned {results.TotalHits} hit(s), expected {expectedHits}.");

static void Assert(bool condition, string message)
{
    if (!condition)
        throw new InvalidOperationException(message);
}

// LINQ smoke test model.
file sealed class NativeSmokeDoc
{
    public string? Title { get; set; }
    public int Year { get; set; }
    public string? Status { get; set; }
    public bool IsPublished { get; set; }
}

file static class NativeSmokeFields
{
    public static readonly LeanField<NativeSmokeDoc, string> Title       = new("title",       FieldType.Text,    true, true, true);
    public static readonly LeanField<NativeSmokeDoc, int>    Year        = new("year",        FieldType.Numeric, true, true, true);
    public static readonly LeanField<NativeSmokeDoc, string> Status      = new("status",      FieldType.String,  true, true, true);
    public static readonly LeanField<NativeSmokeDoc, bool>   IsPublished = new("isPublished", FieldType.String,  true, true, true);
}

file sealed class NativeSmokeDocMap : LeanDocumentMap<NativeSmokeDoc>
{
    public override string DocumentName => "doc";
    public override bool StrictSchema => true;
    public override IReadOnlyList<LeanFieldBinding<NativeSmokeDoc>> Fields { get; } = new[]
    {
        new LeanFieldBinding<NativeSmokeDoc>("title",       FieldType.Text,    true, true, true),
        new LeanFieldBinding<NativeSmokeDoc>("year",        FieldType.Numeric, true, true, true),
        new LeanFieldBinding<NativeSmokeDoc>("status",      FieldType.String,  true, true, true),
        new LeanFieldBinding<NativeSmokeDoc>("isPublished", FieldType.String,  true, true, true),
    };
    public override LeanDocument ToDocument(NativeSmokeDoc d) => throw new NotSupportedException();
    public override NativeSmokeDoc FromStoredDocument(StoredDocument d) => new()
    {
        Title       = d.GetFirst("title"),
        Year        = d.GetFirst("year") is { } s && int.TryParse(s, out var y) ? y : 0,
        Status      = d.GetFirst("status"),
        IsPublished = d.GetFirst("isPublished") == "true",
    };
    public override IndexSchema CreateSchema(bool strict)
    {
        var s = new IndexSchema { StrictMode = strict };
        foreach (var f in Fields) s.Add(new FieldMapping(f.Name, f.FieldType) { IsStored = f.IsStored, IsIndexed = f.IsIndexed, IsRequired = f.IsRequired });
        return s;
    }
}

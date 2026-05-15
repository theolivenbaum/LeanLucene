using BenchmarkDotNet.Attributes;
using Rowles.LeanCorpus.Analysis.Analysers;

namespace Rowles.LeanCorpus.Benchmarks;

/// <summary>
/// Measures indexing overhead of <see cref="SynonymGraphFilter"/> at different synonym map sizes.
/// </summary>
[MemoryDiagnoser]
[HtmlExporter]
[JsonExporterAttribute.Full]
[MarkdownExporterAttribute.GitHub]
[RPlotExporter]
[SimpleJob]
public class SynonymBenchmarks
{
    public static IEnumerable<int> DocCounts => BenchmarkData.GetDocCounts(BenchmarkData.DefaultDocCount);

    [ParamsSource(nameof(DocCounts))]
    public int DocumentCount { get; set; }

    /// <summary>Number of synonym mappings in the synonym map.</summary>
    [Params(10, 50, 200)]
    public int SynonymCount { get; set; }

    private string[] _documents = [];
    private StandardAnalyser _baseAnalyser = null!;
    private SynonymGraphFilter _synonymFilter = null!;

    [GlobalSetup]
    public void Setup()
    {
        _documents = BenchmarkData.BuildDocuments(DocumentCount);
        _baseAnalyser = new StandardAnalyser();
        _synonymFilter = BuildSynonymFilter(SynonymCount);
    }

    [Benchmark(Baseline = true)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public int LeanCorpus_NoSynonyms()
    {
        int total = 0;
        foreach (var doc in _documents)
            total += _baseAnalyser.Analyse(doc.AsSpan()).Count;
        return total;
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public int LeanCorpus_WithSynonyms()
    {
        int total = 0;
        foreach (var doc in _documents)
        {
            var tokens = _baseAnalyser.Analyse(doc.AsSpan());
            _synonymFilter.Apply(tokens);
            total += tokens.Count;
        }
        return total;
    }

    private static SynonymGraphFilter BuildSynonymFilter(int count)
    {
        var map = new SynonymMap();
        var words = new[]
        {
            "government", "market", "company", "nation", "people", "policy", "leader",
            "economy", "country", "region", "sector", "report", "official", "minister",
            "party", "council", "program", "project", "agency", "office"
        };
        for (int i = 0; i < count; i++)
        {
            var source = words[i % words.Length];
            map.Add(source, [$"{source}_synonym_{i}", $"{source}_alt"]);
        }
        return new SynonymGraphFilter(map);
    }
}

using BenchmarkDotNet.Attributes;
using System.Runtime.CompilerServices;
using Rowles.LeanCorpus.Codecs.Hnsw;
using Rowles.LeanCorpus.Codecs.Vectors;
using Rowles.LeanCorpus.Document;
using Rowles.LeanCorpus.Document.Fields;
using Rowles.LeanCorpus.Search;
using Rowles.LeanCorpus.Search.Queries;
using Rowles.LeanCorpus.Store;
using LeanIndexWriter = Rowles.LeanCorpus.Index.Indexer.IndexWriter;
using LeanIndexWriterConfig = Rowles.LeanCorpus.Index.Indexer.IndexWriterConfig;
using LeanIndexSearcher = Rowles.LeanCorpus.Search.Searcher.IndexSearcher;

namespace Rowles.LeanCorpus.Benchmarks;

/// <summary>
/// Measures HNSW search throughput across
/// <see cref="VectorQuantisation"/> levels: None (float32 baseline),
/// Int8 (scalar quantisation), and BBQ (binary quantisation).
/// </summary>
[MemoryDiagnoser]
[HtmlExporter]
[JsonExporterAttribute.Full]
[MarkdownExporterAttribute.GitHub]
[RPlotExporter]
[SimpleJob]
public class VectorQuantisationBenchmarks
{
    [Params(1_000, 10_000)]
    public int DocCount { get; set; }

    [Params(64, 128)]
    public int Dimension { get; set; }

    /// <summary>Quantisation strategy applied at index time.</summary>
    [Params(VectorQuantisation.None, VectorQuantisation.Int8, VectorQuantisation.BBQ)]
    public VectorQuantisation Quantisation { get; set; }

    private const string FieldName = "emb";
    private const int TopK = 10;

    // Index state — guarded by (DocCount, Dimension, Quantisation) key
    private static readonly Lock s_gate = new();
    private static (int docCount, int dim, VectorQuantisation q) s_lastKey;
    private static bool s_built;
    private static string s_indexPath = string.Empty;
    private static LeanIndexSearcher s_searcher = default!;
    private float[] _query = [];

    [GlobalSetup]
    public void Setup()
    {
        var key = (DocCount, Dimension, Quantisation);
        if (!s_built || s_lastKey != key)
        {
            lock (s_gate)
            {
                if (!s_built || s_lastKey != key)
                {
                    s_indexPath = Path.Combine(BenchmarkHelpers.TempRoot,
                        "lc_vq_bench_" + Guid.NewGuid().ToString("N"));
                    Directory.CreateDirectory(s_indexPath);

                    var rnd = new Random(7);
                    var vectors = new float[DocCount][];
                    for (int i = 0; i < DocCount; i++)
                    {
                        var v = new float[Dimension];
                        for (int d = 0; d < Dimension; d++)
                            v[d] = (float)(rnd.NextDouble() * 2 - 1);
                        vectors[i] = v;
                    }

                    var cfg = new LeanIndexWriterConfig
                    {
                        BuildHnswOnFlush = true,
                        NormaliseVectors = true,
                        VectorQuantisation = Quantisation,
                        HnswBuildConfig = new HnswBuildConfig
                            { M = 16, M0 = 32, EfConstruction = 100 },
                        HnswSeed = 1L,
                    };

                    using var writer = new LeanIndexWriter(
                        new MMapDirectory(s_indexPath), cfg);
                    for (int i = 0; i < vectors.Length; i++)
                    {
                        var doc = new LeanDocument();
                        doc.Add(new VectorField(FieldName,
                            new ReadOnlyMemory<float>(vectors[i])));
                        writer.AddDocument(doc);
                    }
                    writer.Commit();

                    s_searcher = new LeanIndexSearcher(
                        new MMapDirectory(s_indexPath));

                    s_lastKey = key;
                    s_built = true;
                }
            }
        }

        _query = new float[Dimension];
        var qrnd = new Random(7);
        for (int d = 0; d < Dimension; d++)
            _query[d] = (float)(qrnd.NextDouble() * 2 - 1);
    }

    [Benchmark(Baseline = true, Description = "HNSW search")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public int Search()
    {
        var q = new VectorQuery(FieldName, _query, topK: TopK);
        return s_searcher.Search(q, TopK).TotalHits;
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        // Static resources persist for class lifetime.
    }
}

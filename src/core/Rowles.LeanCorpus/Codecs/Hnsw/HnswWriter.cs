using System.IO;
using System.Text;
using Rowles.LeanCorpus.Codecs.CodecKit;
using Rowles.LeanCorpus.Codecs.CodecKit.Formats;

namespace Rowles.LeanCorpus.Codecs.Hnsw;

/// <summary>
/// Writes a frozen <see cref="HnswGraph"/> to disc.
/// </summary>
internal static class HnswWriter
{
    public static void Write(string filePath, HnswGraph graph, int dimension, bool normalised)
    {
        ArgumentNullException.ThrowIfNull(graph);
        if (!graph.IsReadOnly)
            throw new InvalidOperationException("HnswGraph must be frozen before writing.");

        using var bodyMs = new MemoryStream();
        using var bodyBw = new BinaryWriter(bodyMs, Encoding.UTF8, leaveOpen: true);

        bodyBw.Write(dimension);
        bodyBw.Write((byte)(normalised ? 1 : 0));
        bodyBw.Write(graph.M);
        bodyBw.Write(graph.M0);
        bodyBw.Write(graph.EfConstruction);
        bodyBw.Write(graph.Seed);
        bodyBw.Write(graph.EntryPoint);
        bodyBw.Write(graph.MaxLevel);
        bodyBw.Write(graph.NodeCount);

        int levelCount = graph.LevelCount;
        bodyBw.Write(levelCount);

        for (int level = levelCount - 1; level >= 0; level--)
        {
            var nodes = graph.GetNodesAtLevel(level).ToArray();
            bodyBw.Write(nodes.Length);
            foreach (var docId in nodes)
            {
                var neighbours = graph.GetNeighbours(docId, level);
                bodyBw.Write(docId);
                bodyBw.Write(neighbours.Count);
                foreach (var n in neighbours)
                    bodyBw.Write(n);
            }
        }

        bodyBw.Flush();
        byte[] body = bodyMs.ToArray();

        using var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
        using var writer = new BinaryWriter(fs, Encoding.UTF8, leaveOpen: false);
        CodecFileHeader.Write(writer, CodecFormats.Hnsw, body);
    }
}

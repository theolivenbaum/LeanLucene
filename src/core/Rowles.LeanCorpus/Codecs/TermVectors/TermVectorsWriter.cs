using System.IO;
using System.Text;
using Rowles.LeanCorpus.Codecs.CodecKit;
using Rowles.LeanCorpus.Codecs.CodecKit.Formats;

namespace Rowles.LeanCorpus.Codecs.TermVectors;

/// <summary>
/// Writes per-document term vectors to .tvd (data) and .tvx (offset index) files.
/// Format: .tvx: [docCount:int32] [long[] offsets into .tvd]
///         .tvd per doc: [fieldCount:int32] per field: [fieldName:string] [termCount:int32]
///              per term: [term:string] [freq:int32] [posCount:int32] [positions:int32[]] [hasPayloads:bool] [payloads]
/// </summary>
internal static class TermVectorsWriter
{
    public static void Write(string tvdPath, string tvxPath,
        IReadOnlyList<Dictionary<string, List<TermVectorEntry>>?> docs)
    {
        // Buffer .tvd body and track body-relative offsets.
        var bodyOffsets = new long[docs.Count];
        byte[] tvdBody;
        using (var bodyMs = new MemoryStream())
        using (var bodyBw = new BinaryWriter(bodyMs, Encoding.UTF8, leaveOpen: true))
        {
            for (int d = 0; d < docs.Count; d++)
            {
                bodyOffsets[d] = bodyMs.Position;
                var fields = docs[d];
                if (fields is null)
                {
                    bodyBw.Write(0);
                    continue;
                }
                bodyBw.Write(fields.Count);
                foreach (var (fieldName, entries) in fields)
                {
                    bodyBw.Write(fieldName);
                    bodyBw.Write(entries.Count);
                    foreach (var entry in entries)
                    {
                        bodyBw.Write(entry.Term);
                        bodyBw.Write(entry.Freq);
                        bodyBw.Write(entry.Positions.Length);
                        foreach (var pos in entry.Positions)
                            bodyBw.Write(pos);
                        WritePayloads(bodyBw, entry);
                    }
                }
            }
            bodyBw.Flush();
            tvdBody = bodyMs.ToArray();
        }

        // Write .tvd file and capture envelope header size for offset computation.
        long headerSize;
        using (var tvdFs = new FileStream(tvdPath, FileMode.Create, FileAccess.Write, FileShare.None))
        using (var tvdWriter = new BinaryWriter(tvdFs, Encoding.UTF8, leaveOpen: false))
        {
            CodecFileHeader.Write(tvdWriter, CodecFormats.TermVectors, tvdBody);
            tvdWriter.Flush();
            headerSize = tvdFs.Position - tvdBody.Length;
        }

        // Compute file-absolute offsets: envelope header size + body-relative offset.
        var offsets = new long[docs.Count];
        for (int d = 0; d < docs.Count; d++)
            offsets[d] = headerSize + bodyOffsets[d];

        // Buffer .tvx body.
        byte[] tvxBody;
        using (var tvxBodyMs = new MemoryStream())
        using (var tvxBw = new BinaryWriter(tvxBodyMs, Encoding.UTF8, leaveOpen: true))
        {
            tvxBw.Write(docs.Count);
            foreach (var offset in offsets)
                tvxBw.Write(offset);
            tvxBw.Flush();
            tvxBody = tvxBodyMs.ToArray();
        }

        // Write .tvx index.
        using var tvxFs = new FileStream(tvxPath, FileMode.Create, FileAccess.Write, FileShare.None);
        using var tvxWriter = new BinaryWriter(tvxFs, Encoding.UTF8, leaveOpen: false);
        CodecFileHeader.Write(tvxWriter, CodecFormats.TermVectors, tvxBody);
    }

    private static void WritePayloads(BinaryWriter writer, TermVectorEntry entry)
    {
        bool hasPayloads = entry.Payloads is { Length: > 0 } payloads
            && payloads.Any(static payload => payload is { Length: > 0 });
        writer.Write(hasPayloads);

        if (!hasPayloads)
            return;

        if (entry.Payloads is null || entry.Payloads.Length != entry.Positions.Length)
            throw new InvalidDataException($"Term vector payload count for term '{entry.Term}' must match the position count.");

        for (int i = 0; i < entry.Payloads.Length; i++)
        {
            var payload = entry.Payloads[i];
            writer.Write(payload?.Length ?? 0);
            if (payload is { Length: > 0 })
                writer.Write(payload);
        }
    }
}

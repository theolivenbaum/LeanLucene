using System.IO;
using System.Text;
using Rowles.LeanCorpus.Codecs.CodecKit;
using Rowles.LeanCorpus.Codecs.CodecKit.Formats;
using Rowles.LeanCorpus.Store;

namespace Rowles.LeanCorpus.Codecs.DocValues;

/// <summary>
/// Writes multi-valued binary DocValues in a column-stride format (.dvb).
/// </summary>
internal static class BinaryDocValuesWriter
{
    public static void Write(
        string filePath,
        IReadOnlyDictionary<string, IReadOnlyList<byte[]>?[]> fields,
        int docCount,
        bool durable = false)
    {
        using var bodyMs = new MemoryStream();
        using var bw = new BinaryWriter(bodyMs, Encoding.UTF8, leaveOpen: true);
        bw.Write(fields.Count);

        foreach (var (fieldName, values) in fields)
            WriteFieldBlock(bw, fieldName, values, docCount);

        bw.Flush();
        byte[] body = bodyMs.ToArray();
        using var output = new IndexOutput(filePath, durable);
        CodecFileHeader.Write(output, CodecFormats.BinaryDocValues, body);
    }

    internal static void WriteFieldBlock(
        BinaryWriter bw,
        string fieldName,
        IReadOnlyList<byte[]>?[] values,
        int docCount)
    {
        WriteString(bw, fieldName);
        bw.Write(docCount);

        var starts = new int[docCount + 1];
        var allValues = new List<byte[]>();
        for (int docId = 0; docId < docCount; docId++)
        {
            starts[docId] = allValues.Count;
            if ((uint)docId < (uint)values.Length && values[docId] is { Count: > 0 } source)
                allValues.AddRange(source);
        }
        starts[docCount] = allValues.Count;

        for (int i = 0; i < starts.Length; i++)
            bw.Write(starts[i]);

        bw.Write(allValues.Count);
        var byteOffsets = new int[allValues.Count + 1];
        int totalBytes = 0;
        for (int i = 0; i < allValues.Count; i++)
        {
            byteOffsets[i] = totalBytes;
            totalBytes += allValues[i].Length;
        }
        byteOffsets[^1] = totalBytes;

        for (int i = 0; i < byteOffsets.Length; i++)
            bw.Write(byteOffsets[i]);

        foreach (var value in allValues)
            bw.Write(value);
    }

    private static void WriteString(BinaryWriter bw, string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        bw.Write7BitEncodedInt(bytes.Length);
        bw.Write(bytes);
    }
}

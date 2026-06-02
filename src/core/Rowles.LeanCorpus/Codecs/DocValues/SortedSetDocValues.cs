using System.IO;
using System.Text;
using Rowles.LeanCorpus.Codecs.CodecKit;
using Rowles.LeanCorpus.Codecs.CodecKit.Formats;
using Rowles.LeanCorpus.Store;

namespace Rowles.LeanCorpus.Codecs.DocValues;

/// <summary>
/// Writes multi-valued string DocValues in a column-stride format (.dss).
/// </summary>
internal static class SortedSetDocValuesWriter
{
    public static void Write(
        string filePath,
        IReadOnlyDictionary<string, IReadOnlyList<string>?[]> fields,
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
        CodecFileHeader.Write(output, CodecFormats.SortedSetDocValues, body);
    }

    internal static void WriteFieldBlock(
        BinaryWriter bw,
        string fieldName,
        IReadOnlyList<string>?[] values,
        int docCount)
    {
        WriteFieldName(bw, fieldName);
        bw.Write(docCount);

        var ordSet = new SortedSet<string>(StringComparer.Ordinal);
        var perDoc = new string[docCount][];
        var starts = new int[docCount + 1];
        int totalOrdinals = 0;

        for (int docId = 0; docId < docCount; docId++)
        {
            starts[docId] = totalOrdinals;
            string[] docValues = [];
            if ((uint)docId < (uint)values.Length && values[docId] is { Count: > 0 } source)
            {
                docValues = source
                    .Where(static value => value is not null)
                    .Distinct(StringComparer.Ordinal)
                    .Order(StringComparer.Ordinal)
                    .ToArray();

                foreach (var value in docValues)
                    ordSet.Add(value);
            }

            perDoc[docId] = docValues;
            totalOrdinals += docValues.Length;
        }
        starts[docCount] = totalOrdinals;

        var ordList = ordSet.ToArray();
        var ordMap = new Dictionary<string, int>(ordList.Length, StringComparer.Ordinal);
        for (int i = 0; i < ordList.Length; i++)
            ordMap[ordList[i]] = i;

        bw.Write(ordList.Length);
        foreach (var value in ordList)
            WriteString(bw, value);

        for (int i = 0; i < starts.Length; i++)
            bw.Write(starts[i]);

        bw.Write(totalOrdinals);
        foreach (var docValues in perDoc)
        {
            foreach (var value in docValues)
                bw.Write7BitEncodedInt(ordMap[value]);
        }
    }

    private static void WriteFieldName(BinaryWriter bw, string fieldName)
        => WriteString(bw, fieldName);

    private static void WriteString(BinaryWriter bw, string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        bw.Write7BitEncodedInt(bytes.Length);
        bw.Write(bytes);
    }
}

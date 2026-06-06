using System.Text;
using Rowles.LeanCorpus.Codecs.CodecKit;
using Rowles.LeanCorpus.Codecs.CodecKit.Formats;
using Rowles.LeanCorpus.Store;

namespace Rowles.LeanCorpus.Codecs.DocValues;

/// <summary>
/// Reads quantised per-field norm values as compact byte arrays.
/// Uses memory-mapped I/O to avoid loading the entire file into a managed byte[].
/// </summary>
internal static class NormsReader
{
    public static NormsData Read(string filePath)
    {
        using var input = new IndexInput(filePath);

        byte version = CodecFileHeader.ReadVersion(input, CodecFormats.Norms);

        int fieldCount = input.ReadInt32();

        var result = new NormsData();

        for (int f = 0; f < fieldCount; f++)
        {
            int fieldNameLen = input.ReadInt32();

            byte[] nameBytes = input.ReadBytes(fieldNameLen);
            string fieldName = Encoding.UTF8.GetString(nameBytes, 0, fieldNameLen);

            int docCount = input.ReadInt32();

            byte[] norms = input.ReadBytes(docCount);

            result.Norms[fieldName] = norms;

            // Current format: sparse boost data
            int boostCount = input.ReadInt32();
            if ((uint)boostCount > (uint)docCount)
                throw new InvalidDataException($"Invalid norms file: boost count {boostCount} exceeds document count {docCount} for field '{fieldName}'.");

            float[]? boosts = null;
            for (int i = 0; i < boostCount; i++)
            {
                int docId = input.ReadInt32();
                float boost = input.ReadSingle();

                if ((uint)docId >= (uint)docCount)
                    throw new InvalidDataException($"Invalid norms file: boost doc ID {docId} is outside field '{fieldName}' document count {docCount}.");

                boosts ??= CreateDefaultBoosts(docCount);
                boosts[docId] = boost;
            }

            if (boosts is not null)
                result.Boosts[fieldName] = boosts;
        }

        return result;
    }

    private static float[] CreateDefaultBoosts(int docCount)
    {
        var boosts = new float[docCount];
        Array.Fill(boosts, 1.0f);
        return boosts;
    }
}

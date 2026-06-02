using Rowles.LeanCorpus.Codecs.CodecKit.Compression;
using System;
using System.Buffers;
using System.IO;
using System.IO.Compression;

namespace Rowles.LeanCorpus.Codecs.CodecKit.Compression.Providers;

internal sealed class DeflateProvider : ICompressionProvider
{
    public static DeflateProvider Instance { get; } = new();

    private DeflateProvider() { }

    public byte[] Compress(ReadOnlySpan<byte> data, CodecCompressionLevel level)
    {
        using var output = new MemoryStream(Math.Max(data.Length / 2, 256));
        using (var deflate = new DeflateStream(output, MapLevel(level), leaveOpen: true))
            deflate.Write(data);
        return output.ToArray();
    }

    public byte[] Decompress(ReadOnlySpan<byte> compressedData)
    {
        byte[] rented = ArrayPool<byte>.Shared.Rent(compressedData.Length);
        try
        {
            compressedData.CopyTo(rented);
            using var input = new MemoryStream(rented, 0, compressedData.Length, false);
            using var output = new MemoryStream(compressedData.Length * 4);
            using (var deflate = new DeflateStream(input, CompressionMode.Decompress))
                deflate.CopyTo(output);
            return output.ToArray();
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(rented);
        }
    }

    private static CompressionLevel MapLevel(CodecCompressionLevel level) => level switch
    {
        CodecCompressionLevel.Fastest      => CompressionLevel.Fastest,
        CodecCompressionLevel.Optimal      => CompressionLevel.Optimal,
#if NET7_0_OR_GREATER
        CodecCompressionLevel.SmallestSize => CompressionLevel.SmallestSize,
#else
        CodecCompressionLevel.SmallestSize => CompressionLevel.Optimal,
#endif
        _ => CompressionLevel.Optimal
    };
}

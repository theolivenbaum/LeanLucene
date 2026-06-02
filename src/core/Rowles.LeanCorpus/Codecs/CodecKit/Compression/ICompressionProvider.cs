using System;

namespace Rowles.LeanCorpus.Codecs.CodecKit.Compression;

/// <summary>
/// Provides compression and decompression for byte sequences.
/// Implementations must be thread-safe and stateless.
/// </summary>
internal interface ICompressionProvider
{
    /// <summary>
    /// Compresses <paramref name="data"/> at the requested level and returns the compressed bytes.
    /// </summary>
    byte[] Compress(ReadOnlySpan<byte> data, CodecCompressionLevel level);

    /// <summary>
    /// Decompresses <paramref name="compressedData"/> and returns the original bytes.
    /// Throws if the data is corrupt or cannot be decompressed.
    /// </summary>
    byte[] Decompress(ReadOnlySpan<byte> compressedData);
}

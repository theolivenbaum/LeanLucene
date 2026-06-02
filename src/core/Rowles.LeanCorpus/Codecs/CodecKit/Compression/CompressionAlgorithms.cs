namespace Rowles.LeanCorpus.Codecs.CodecKit.Compression;

/// <summary>
/// Well-known compression algorithm identifiers.
/// </summary>
internal static class CompressionAlgorithms
{
    public static CompressionAlgorithmId Deflate { get; } = new("deflate");
    public static CompressionAlgorithmId Brotli { get; } = new("brotli");
    public static CompressionAlgorithmId Lz4 { get; } = new("lz4");
    public static CompressionAlgorithmId Zstd { get; } = new("zstd");
    public static CompressionAlgorithmId Snappy { get; } = new("snappy");
}

namespace Rowles.LeanCorpus.Codecs.CodecKit.Compression;

/// <summary>
/// Compression level hint for codecs that support compression.
/// </summary>
internal enum CodecCompressionLevel
{
    Fastest = 0,
    Optimal = 1,
    SmallestSize = 2,
}

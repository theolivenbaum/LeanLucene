using Rowles.LeanCorpus.Codecs.CodecKit.Codecs;
using System;

namespace Rowles.LeanCorpus.Codecs.CodecKit.Compression;

/// <summary>
/// Identifies a compression algorithm in the <see cref="CodecRegistry"/>.
/// </summary>
internal sealed record CompressionAlgorithmId(string Name)
{
    public override string ToString() => Name;
}

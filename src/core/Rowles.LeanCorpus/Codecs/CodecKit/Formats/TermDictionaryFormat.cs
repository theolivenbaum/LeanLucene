using Rowles.LeanCorpus.Codecs.CodecKit.Codecs;

namespace Rowles.LeanCorpus.Codecs.CodecKit.Formats;

/// <summary>
/// Term dictionary (.tim/.dic) wire format (v3 FST).
/// Layout: [FST blob bytes] — the FST blob is self-describing (starts with its own "FST1" magic).
/// </summary>
internal static class TermDictionaryFormat
{
    internal sealed class Data
    {
        public int FstLength { get; init; }
        public byte[] FstBlob { get; init; } = [];
    }

    internal static readonly ICodec<Data> V3 = Codec.Record<Data>()
        .Field("fstLength", d => d.FstLength, Codec.Int32LE)
        .Field("fstBlob",   d => d.FstBlob,   Codec.UInt8.RepeatFrom("fstLength"))
        .Build<int, byte[]>((fstLength, fstBlob) =>
            new Data { FstLength = fstLength, FstBlob = fstBlob });
}

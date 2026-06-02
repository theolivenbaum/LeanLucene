using Rowles.LeanCorpus.Codecs.CodecKit.Codecs;

namespace Rowles.LeanCorpus.Codecs.CodecKit.Formats;

/// <summary>
/// CodecKit format declarations for all codec file types.
/// Each wraps the existing body as opaque bytes in a <c>VersionEnvelope</c>
/// providing version dispatch and forward compatibility.
/// When dual-format read is wired, these replace the manual magic+version header.
/// </summary>
internal static class CodecFormats
{
    internal static readonly ICodec<byte[]> Norms = Create("nrm", CodecConstants.NormsVersion);
    internal static readonly ICodec<byte[]> FieldLengths = Create("fln", CodecConstants.FieldLengthVersion);
    internal static readonly ICodec<byte[]> NumericDocValues = Create("ndv", CodecConstants.NumericDocValuesVersion);
    internal static readonly ICodec<byte[]> SortedDocValues = Create("sdv", CodecConstants.SortedDocValuesVersion);
    internal static readonly ICodec<byte[]> BinaryDocValues = Create("bdv", CodecConstants.BinaryDocValuesVersion);
    internal static readonly ICodec<byte[]> SortedSetDocValues = Create("ssdv", CodecConstants.SortedSetDocValuesVersion);
    internal static readonly ICodec<byte[]> SortedNumericDocValues = Create("sndv", CodecConstants.SortedNumericDocValuesVersion);
    internal static readonly ICodec<byte[]> StoredFields = Create("fdt", CodecConstants.StoredFieldsVersion);
    internal static readonly ICodec<byte[]> Postings = Create("pos", CodecConstants.PostingsVersion);
    internal static readonly ICodec<byte[]> TermVectors = Create("tvx", CodecConstants.TermVectorsVersion);
    internal static readonly ICodec<byte[]> TermDictionary = Create("tim", CodecConstants.TermDictionaryVersion);
    internal static readonly ICodec<byte[]> Hnsw = Create("hnsw", CodecConstants.HnswVersion);
    internal static readonly ICodec<byte[]> Vectors = Create("vec", CodecConstants.VectorVersion);
    internal static readonly ICodec<byte[]> QuantisedVectors = Create("qvec", CodecConstants.QuantisedVectorVersion);
    internal static readonly ICodec<byte[]> Bkd = Create("bkd", CodecConstants.BKDVersion);
    internal static readonly ICodec<byte[]> RoaringBitmap = Create("rbm", CodecConstants.RoaringBitmapVersion);

    private static ICodec<byte[]> Create(string ext, byte currentVersion)
    {
        return Codec.VersionEnvelope<byte[], byte>(
            versionCodec: Codec.UInt8,
            bodyLengthCodec: Codec.VarInt64,
            unknown: (ver, body) => body,
            cases: Codec.VersionCase<byte[], byte[]>(currentVersion, $"{ext}-v{currentVersion}", Codec.BytesOwnedRemaining()));
    }
}

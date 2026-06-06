namespace Rowles.LeanCorpus.Codecs;

/// <summary>
/// Format version constants for all codec file types.
/// Every codec file uses the CodecKit format: [byte version][VarInt64 bodyLen][body].
/// </summary>
internal static class CodecConstants
{
    // Per-format version numbers — all set to 1 for 2.0.0.
    public const byte TermDictionaryVersion = 1;
    public const byte PostingsVersion = 1;
    public const byte NormsVersion = 1;
    public const byte VectorVersion = 1;
    public const byte QuantisedVectorVersion = 1;
    public const byte HnswVersion = 1;
    public const byte StoredFieldsVersion = 1;
    public const byte TermVectorsVersion = 1;
    public const byte NumericDocValuesVersion = 1;
    public const byte SortedDocValuesVersion = 1;
    public const byte SortedSetDocValuesVersion = 1;
    public const byte SortedNumericDocValuesVersion = 1;
    public const byte BinaryDocValuesVersion = 1;
    public const byte BKDVersion = 1;
    public const byte FieldLengthVersion = 1;
    public const byte RoaringBitmapVersion = 1;
}

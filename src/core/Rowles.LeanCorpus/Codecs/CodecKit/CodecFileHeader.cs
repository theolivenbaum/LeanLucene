using System.Buffers;
using System.Text;
using Rowles.LeanCorpus.Codecs.CodecKit.Codecs;
using Rowles.LeanCorpus.Store;

namespace Rowles.LeanCorpus.Codecs.CodecKit;

/// <summary>
/// Dual-format read/write dispatch for codec files.
/// Legacy format: [int32 LE magic=0x4C4C4E31 "LLN1"][byte version][body]
/// CodecKit format: [byte version][VarInt64 bodyLen][body]
/// Detection: legacy files start with byte 0x31 (first LE byte of magic);
/// CodecKit version bytes are ≤ 49 in practice.
/// </summary>
internal static class CodecFileHeader
{
    /// <summary>First byte of the legacy magic (0x4C4C4E31 stored LE = bytes 31 4E 4C 4C).</summary>
    private const byte LegacyFirstByte = 0x31;
    private const int LegacyMagic = 0x4C4C_4E31;
    /// <summary>Highest version tag we consider valid for format detection.</summary>
    private const byte MaxKnownVersion = 49;

    /// <summary>
    /// The result of reading a codec file body, including the format version.
    /// </summary>
    internal readonly struct ReadResult
    {
        public byte[] Body { get; }
        public byte Version { get; }
        public ReadResult(byte[] body, byte version) { Body = body; Version = version; }
    }

    // ═══════════════════════════════════════════════════
    //  IndexOutput / IndexInput
    // ═══════════════════════════════════════════════════

    internal static ReadResult Read(IndexInput input, ICodec<byte[]> format)
    {
        byte firstByte = input.ReadByte();
        if (firstByte == LegacyFirstByte)
            return ReadLegacy(input);
        input.Seek(input.Position - 1);
        return ReadCodecKit(input, format);
    }

    internal static byte ReadVersion(IndexInput input, ICodec<byte[]> format)
    {
        byte firstByte = input.ReadByte();
        if (firstByte == LegacyFirstByte)
            return ReadLegacyVersion(input);
        input.Seek(input.Position - 1);
        return ReadCodecKitVersion(input);
    }

    internal static void Write(IndexOutput output, ICodec<byte[]> format, byte[] body)
    {
        var writer = new Adapters.IndexOutputBuffer(output);
        var ctx = new CodecContext(CodecOptions.Default, CodecRegistry.Default);
        format.Encode(body, writer, ctx);
    }

    internal static (T Value, byte Version) Read<T>(IndexInput input, ICodec<byte[]> format, ICodec<T> bodyCodec)
    {
        var result = Read(input, format);
        var seq = new ReadOnlySequence<byte>(result.Body);
        var reader = new SequenceReader<byte>(seq);
        var ctx = new CodecContext(CodecOptions.Default, CodecRegistry.Default);
        T value = bodyCodec.Decode(ref reader, ctx);
        return (value, result.Version);
    }

    // ═══════════════════════════════════════════════════
    //  BinaryWriter / BinaryReader
    // ═══════════════════════════════════════════════════

    internal static void Write(BinaryWriter writer, ICodec<byte[]> format, byte[] body)
    {
        var buf = new ArrayBufferWriter<byte>(body.Length + 16);
        var ctx = new CodecContext(CodecOptions.Default, CodecRegistry.Default);
        format.Encode(body, buf, ctx);
        writer.Write(buf.WrittenSpan);
    }

    internal static ReadResult Read(BinaryReader reader, ICodec<byte[]> format)
    {
        byte firstByte = reader.ReadByte();
        if (firstByte == LegacyFirstByte)
            return ReadLegacy(reader);
        reader.BaseStream.Position -= 1;
        return ReadCodecKit(reader, format);
    }

    internal static byte ReadVersion(BinaryReader reader, ICodec<byte[]> format)
    {
        byte firstByte = reader.ReadByte();
        if (firstByte == LegacyFirstByte)
            return ReadLegacyVersion(reader);
        reader.BaseStream.Position -= 1;
        return ReadCodecKitVersion(reader);
    }

    // ═══════════════════════════════════════════════════
    //  IndexInput internals
    // ═══════════════════════════════════════════════════

    private static ReadResult ReadLegacy(IndexInput input)
    {
        // Remaining 3 magic bytes: 4E 4C 4C
        int m2 = input.ReadByte(), m3 = input.ReadByte(), m4 = input.ReadByte();
        if (m2 != 0x4E || m3 != 0x4C || m4 != 0x4C)
            throw new InvalidDataException(
                $"Invalid legacy header: expected LLN1 magic, got {LegacyFirstByte:X2}{m2:X2}{m3:X2}{m4:X2}");

        byte version = input.ReadByte();
        long remaining = input.Length - input.Position;
        byte[] body = new byte[remaining];
        for (long i = 0; i < remaining; i++)
            body[i] = input.ReadByte();

        return new ReadResult(body, version);
    }

    private static ReadResult ReadCodecKit(IndexInput input, ICodec<byte[]> format)
    {
        long remaining = input.Length - input.Position;
        if (remaining < 1)
            throw new InvalidDataException("CodecKit file is truncated: no payload bytes found.");
        byte[] raw = new byte[remaining];
        for (long i = 0; i < remaining; i++)
            raw[i] = input.ReadByte();

        var seq = new ReadOnlySequence<byte>(raw);
        var reader = new SequenceReader<byte>(seq);
        var ctx = new CodecContext(CodecOptions.Default, CodecRegistry.Default);
        byte[] body;
        try
        {
            body = format.Decode(ref reader, ctx);
        }
        catch (Exception ex) when (ex is not InvalidDataException)
        {
            throw new InvalidDataException("CodecKit file is corrupt or truncated.", ex);
        }

        byte version = raw[0];
        return new ReadResult(body, version);
    }

    private static byte ReadLegacyVersion(IndexInput input)
    {
        int m2 = input.ReadByte(), m3 = input.ReadByte(), m4 = input.ReadByte();
        if (m2 != 0x4E || m3 != 0x4C || m4 != 0x4C)
            throw new InvalidDataException(
                $"Invalid legacy header: expected LLN1 magic, got {LegacyFirstByte:X2}{m2:X2}{m3:X2}{m4:X2}");

        return input.ReadByte();
    }

    private static byte ReadCodecKitVersion(IndexInput input)
    {
        byte version = input.ReadByte();
        SkipVarInt64(input);
        return version;
    }

    // ═══════════════════════════════════════════════════
    //  BinaryReader internals
    // ═══════════════════════════════════════════════════

    private static ReadResult ReadLegacy(BinaryReader reader)
    {
        int m2 = reader.ReadByte(), m3 = reader.ReadByte(), m4 = reader.ReadByte();
        if (m2 != 0x4E || m3 != 0x4C || m4 != 0x4C)
            throw new InvalidDataException(
                $"Invalid legacy header: expected LLN1 magic, got {LegacyFirstByte:X2}{m2:X2}{m3:X2}{m4:X2}");

        byte version = reader.ReadByte();
        long remaining = reader.BaseStream.Length - reader.BaseStream.Position;
        byte[] body = reader.ReadBytes((int)remaining);
        return new ReadResult(body, version);
    }

    private static ReadResult ReadCodecKit(BinaryReader reader, ICodec<byte[]> format)
    {
        long remaining = reader.BaseStream.Length - reader.BaseStream.Position;
        if (remaining < 1)
            throw new InvalidDataException("CodecKit file is truncated: no payload bytes found.");
        byte[] raw = reader.ReadBytes((int)remaining);

        var seq = new ReadOnlySequence<byte>(raw);
        var seqReader = new SequenceReader<byte>(seq);
        var ctx = new CodecContext(CodecOptions.Default, CodecRegistry.Default);
        byte[] body;
        try
        {
            body = format.Decode(ref seqReader, ctx);
        }
        catch (Exception ex) when (ex is not InvalidDataException)
        {
            throw new InvalidDataException("CodecKit file is corrupt or truncated.", ex);
        }

        byte version = raw[0];
        return new ReadResult(body, version);
    }

    private static byte ReadLegacyVersion(BinaryReader reader)
    {
        int m2 = reader.ReadByte(), m3 = reader.ReadByte(), m4 = reader.ReadByte();
        if (m2 != 0x4E || m3 != 0x4C || m4 != 0x4C)
            throw new InvalidDataException(
                $"Invalid legacy header: expected LLN1 magic, got {LegacyFirstByte:X2}{m2:X2}{m3:X2}{m4:X2}");

        return reader.ReadByte();
    }

    private static byte ReadCodecKitVersion(BinaryReader reader)
    {
        byte version = reader.ReadByte();
        SkipVarInt64(reader);
        return version;
    }

    // ═══════════════════════════════════════════════════
    //  LEB128 VarInt64 skipping
    // ═══════════════════════════════════════════════════

    private static void SkipVarInt64(IndexInput input)
    {
        for (int i = 0; i < 10; i++)
        {
            byte b = input.ReadByte();
            if ((b & 0x80) == 0) return;
        }
        throw new InvalidDataException("VarInt64 body length is malformed (exceeds 10 bytes).");
    }

    private static void SkipVarInt64(BinaryReader reader)
    {
        for (int i = 0; i < 10; i++)
        {
            byte b = reader.ReadByte();
            if ((b & 0x80) == 0) return;
        }
        throw new InvalidDataException("VarInt64 body length is malformed (exceeds 10 bytes).");
    }
}

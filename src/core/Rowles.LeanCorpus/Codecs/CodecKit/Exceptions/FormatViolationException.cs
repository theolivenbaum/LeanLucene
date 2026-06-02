using Rowles.LeanCorpus.Codecs.CodecKit.Enums;
using System;

namespace Rowles.LeanCorpus.Codecs.CodecKit.Exceptions;

/// <summary>The wire format violates a structural constraint (base for magic, padding, trailing data, unknown discriminator/version).</summary>
internal class FormatViolationException : CodecException
{
    public FormatViolationException(CodecErrorCode errorCode, long byteOffset, string path, string message, Exception? innerException = null)
        : base(errorCode, byteOffset, path, message, innerException)
    {
    }
}

/// <summary>A magic byte pattern did not match.</summary>
internal sealed class MagicMismatchException : FormatViolationException
{
    public MagicMismatchException(long byteOffset, string path, byte[] expected, byte[] actual)
        : base(CodecErrorCode.MagicMismatch, byteOffset, path,
            $"Magic mismatch at offset {byteOffset}: expected [{FormatBytes(expected)}] but got [{FormatBytes(actual)}]. Path: {path}")
    {
        Expected = expected;
        Actual = actual;
    }

    public byte[] Expected { get; }
    public byte[] Actual { get; }

    private static string FormatBytes(byte[] bytes) =>
        string.Join(" ", Array.ConvertAll(bytes, b => b.ToString("X2")));
}

/// <summary>Padding bytes did not match the expected fill value.</summary>
internal sealed class InvalidPaddingException : FormatViolationException
{
    public InvalidPaddingException(long byteOffset, string path, byte expectedByte)
        : base(CodecErrorCode.InvalidPadding, byteOffset, path,
            $"Invalid padding at offset {byteOffset}: expected 0x{expectedByte:X2}. Path: {path}")
    {
        ExpectedByte = expectedByte;
    }

    public InvalidPaddingException(long byteOffset, string path, byte expectedByte, byte actualByte)
        : base(CodecErrorCode.InvalidPadding, byteOffset, path,
            $"Invalid padding at offset {byteOffset}: expected 0x{expectedByte:X2} but got 0x{actualByte:X2}. Path: {path}")
    {
        ExpectedByte = expectedByte;
        ActualByte = actualByte;
    }

    public byte ExpectedByte { get; }
    public byte? ActualByte { get; }
}

/// <summary>Unexpected trailing bytes after the expected payload.</summary>
internal sealed class TrailingDataException : FormatViolationException
{
    public TrailingDataException(long byteOffset, string path, long trailingBytes)
        : base(CodecErrorCode.TrailingData, byteOffset, path,
            $"Trailing data at offset {byteOffset}: {trailingBytes} unexpected bytes. Path: {path}")
    {
        TrailingBytes = trailingBytes;
    }

    public long TrailingBytes { get; }
}

/// <summary>A choice discriminator value has no matching case.</summary>
internal sealed class UnknownDiscriminatorException : FormatViolationException
{
    public UnknownDiscriminatorException(long byteOffset, string path, object discriminatorValue)
        : base(CodecErrorCode.UnknownDiscriminator, byteOffset, path,
            $"Unknown discriminator '{discriminatorValue}' at offset {byteOffset}. Path: {path}")
    {
        DiscriminatorValue = discriminatorValue;
    }

    public object DiscriminatorValue { get; }
}

/// <summary>A version number has no matching case in a Versioned codec.</summary>
internal sealed class UnknownVersionException : FormatViolationException
{
    public UnknownVersionException(long byteOffset, string path, object versionValue)
        : base(CodecErrorCode.UnknownVersion, byteOffset, path,
            $"Unknown version '{versionValue}' at offset {byteOffset}. Path: {path}")
    {
        VersionValue = versionValue;
    }

    public object VersionValue { get; }
}

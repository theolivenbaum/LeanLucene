using Rowles.LeanCorpus.Codecs.CodecKit.Enums;
using System;

namespace Rowles.LeanCorpus.Codecs.CodecKit.Exceptions;

/// <summary>A decoded value is invalid (base for InvalidBoolean, InvalidUtf8).</summary>
internal class InvalidValueException : CodecException
{
    public InvalidValueException(CodecErrorCode errorCode, long byteOffset, string path, string message, Exception? innerException = null)
        : base(errorCode, byteOffset, path, message, innerException)
    {
    }
}

/// <summary>A boolean byte was not 0x00 or 0x01.</summary>
internal sealed class InvalidBooleanException : InvalidValueException
{
    public InvalidBooleanException(long byteOffset, string path, byte actualValue)
        : base(CodecErrorCode.InvalidBoolean, byteOffset, path,
            $"Invalid boolean value 0x{actualValue:X2} at offset {byteOffset}. Expected 0x00 or 0x01. Path: {path}")
    {
        ActualValue = actualValue;
    }

    public byte ActualValue { get; }
}

/// <summary>A byte sequence is not valid UTF-8.</summary>
internal sealed class InvalidUtf8Exception : InvalidValueException
{
    public InvalidUtf8Exception(long byteOffset, string path)
        : base(CodecErrorCode.InvalidUtf8, byteOffset, path,
            $"Invalid UTF-8 sequence at offset {byteOffset}. Path: {path}")
    {
    }
}

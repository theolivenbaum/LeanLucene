using Rowles.LeanCorpus.Codecs.CodecKit.Enums;
using System;

namespace Rowles.LeanCorpus.Codecs.CodecKit.Exceptions;

/// <summary>Data integrity check failed (base for ChecksumMismatch).</summary>
internal class IntegrityException : CodecException
{
    public IntegrityException(CodecErrorCode errorCode, long byteOffset, string path, string message, Exception? innerException = null)
        : base(errorCode, byteOffset, path, message, innerException)
    {
    }
}

/// <summary>A checksum verification failed.</summary>
internal sealed class ChecksumMismatchException : IntegrityException
{
    public ChecksumMismatchException(long byteOffset, string path, string algorithmId, byte[] expected, byte[] actual)
        : base(CodecErrorCode.ChecksumMismatch, byteOffset, path,
            $"Checksum mismatch ({algorithmId}) at offset {byteOffset}. Path: {path}")
    {
        AlgorithmId = algorithmId;
        ExpectedChecksum = expected;
        ActualChecksum = actual;
    }

    public string AlgorithmId { get; }
    public byte[] ExpectedChecksum { get; }
    public byte[] ActualChecksum { get; }
}

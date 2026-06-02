using Rowles.LeanCorpus.Codecs.CodecKit.Enums;
using System;

namespace Rowles.LeanCorpus.Codecs.CodecKit.Exceptions;

/// <summary>An operation requires a delimited scope but none is active (e.g., *Remaining codecs outside LengthPrefixed).</summary>
internal sealed class InvalidScopeException : CodecException
{
    public InvalidScopeException(long byteOffset, string path, string message)
        : base(CodecErrorCode.InvalidScope, byteOffset, path, message)
    {
    }
}

using Rowles.LeanCorpus.Codecs.CodecKit.Enums;
﻿using System;

namespace Rowles.LeanCorpus.Codecs.CodecKit.Exceptions;

/// <summary>A <c>Validate</c> predicate returned false.</summary>
internal sealed class CodecValidationException : CodecException
{
    public CodecValidationException(long byteOffset, string path, string validationMessage)
        : base(CodecErrorCode.ValidationFailed, byteOffset, path,
            $"Validation failed at offset {byteOffset}: {validationMessage}. Path: {path}")
    {
        ValidationMessage = validationMessage;
    }

    public string ValidationMessage { get; }
}

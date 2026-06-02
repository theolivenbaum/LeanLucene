using Rowles.LeanCorpus.Codecs.CodecKit.Enums;
using System;

namespace Rowles.LeanCorpus.Codecs.CodecKit.Codecs;

/// <summary>
/// Immutable configuration for codec operations. All limits are validated at construction time.
/// </summary>
internal sealed record CodecOptions
{
    public long MaxFrameBytes { get; init; } = 64 * 1024 * 1024;        // 64 MB
    public int MaxSequenceElements { get; init; } = 1_000_000;           // 1M
    public int MaxStringBytes { get; init; } = 16 * 1024 * 1024;         // 16 MB
    public int MaxScratchBufferBytes { get; init; } = 64 * 1024 * 1024;  // 64 MB
    public long MaxDecompressedBytes { get; init; } = 256 * 1024 * 1024; // 256 MB
    public int MaxNestingDepth { get; init; } = 64;
    public bool RejectNonCanonicalVarInts { get; init; } = true;
    public Utf8ValidationMode Utf8Validation { get; init; } = Utf8ValidationMode.Strict;

    public static CodecOptions Default { get; } = new();

    public CodecOptions()
    {
        Validate();
    }

    private void Validate()
    {
        if (MaxFrameBytes <= 0) throw new ArgumentOutOfRangeException(nameof(MaxFrameBytes), MaxFrameBytes, "Must be positive.");
        if (MaxSequenceElements <= 0) throw new ArgumentOutOfRangeException(nameof(MaxSequenceElements), MaxSequenceElements, "Must be positive.");
        if (MaxStringBytes <= 0) throw new ArgumentOutOfRangeException(nameof(MaxStringBytes), MaxStringBytes, "Must be positive.");
        if (MaxScratchBufferBytes <= 0) throw new ArgumentOutOfRangeException(nameof(MaxScratchBufferBytes), MaxScratchBufferBytes, "Must be positive.");
        if (MaxDecompressedBytes <= 0) throw new ArgumentOutOfRangeException(nameof(MaxDecompressedBytes), MaxDecompressedBytes, "Must be positive.");
        if (MaxNestingDepth <= 0) throw new ArgumentOutOfRangeException(nameof(MaxNestingDepth), MaxNestingDepth, "Must be positive.");
    }
}

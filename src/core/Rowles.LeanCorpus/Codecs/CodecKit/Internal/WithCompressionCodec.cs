using System;
using System.Buffers;
using Rowles.LeanCorpus.Codecs.CodecKit.Enums;
using Rowles.LeanCorpus.Codecs.CodecKit.Exceptions;
using Rowles.LeanCorpus.Codecs.CodecKit.Codecs;
using Rowles.LeanCorpus.Codecs.CodecKit.Compression;
namespace Rowles.LeanCorpus.Codecs.CodecKit.Internal;

/// <summary>
/// Wraps an inner codec with compression/decompression.
/// Wire format: [compressed-length][compressed-payload]
/// </summary>
internal sealed class WithCompressionCodec<T> : ICodec<T>
{
    private readonly CompressionAlgorithmId _algorithmId;
    private readonly CodecCompressionLevel _level;
    private readonly ICodec<long> _compressedLengthCodec;
    private readonly ICodec<T> _innerCodec;

    public WithCompressionCodec(
        CompressionAlgorithmId algorithmId,
        CodecCompressionLevel level,
        ICodec<long> compressedLengthCodec,
        ICodec<T> innerCodec)
    {
        _algorithmId = algorithmId ?? throw new ArgumentNullException(nameof(algorithmId));
        _compressedLengthCodec = compressedLengthCodec ?? throw new ArgumentNullException(nameof(compressedLengthCodec));
        _innerCodec = innerCodec ?? throw new ArgumentNullException(nameof(innerCodec));
        _level = level;
    }

    public T Decode(ref SequenceReader<byte> reader, CodecContext context)
    {
        var checkpoint = context.Checkpoint(ref reader);
        try
        {
            using var pathGuard = context.PushPath($"{{compressed:{_algorithmId.Name}}}");

            long compressedLength = _compressedLengthCodec.Decode(ref reader, context);

            if (compressedLength < 0)
                throw new InvalidValueException(
                    CodecErrorCode.NegativeLength,
                    context.GetByteOffset(ref reader),
                    context.CurrentPath,
                    $"Negative compressed length: {compressedLength}");

            if (compressedLength > context.Options.MaxFrameBytes)
                throw new LimitExceededException(
                    CodecErrorCode.FrameTooLarge,
                    context.GetByteOffset(ref reader),
                    context.CurrentPath,
                    "CompressedLength", compressedLength, context.Options.MaxFrameBytes);

            int compLen = (int)compressedLength;
            if (reader.Remaining < compLen)
                throw new InsufficientDataException(
                    context.GetByteOffset(ref reader),
                    context.CurrentPath, compLen, (int)reader.Remaining);

            var compressedSequence = reader.Sequence.Slice(reader.Position, compLen);
            reader.Advance(compLen);

            var provider = context.Registry.GetCompressionProvider(_algorithmId);

            // Flatten the compressed sequence to a span for the provider
            byte[] decompressed;
            try
            {
                if (compressedSequence.IsSingleSegment)
                    decompressed = provider.Decompress(compressedSequence.FirstSpan);
                else
                    decompressed = provider.Decompress(compressedSequence.ToArray());
            }
            catch (Exception ex) when (ex is not CodecException)
            {
                throw new InvalidValueException(
                    CodecErrorCode.DecompressionFailed,
                    context.GetByteOffset(ref reader),
                    context.CurrentPath,
                    $"Decompression failed: {ex.Message}", ex);
            }

            if (decompressed.Length > context.Options.MaxDecompressedBytes)
                throw new LimitExceededException(
                    CodecErrorCode.DecompressionLimitExceeded,
                    context.GetByteOffset(ref reader),
                    context.CurrentPath,
                    "DecompressedLength", decompressed.Length, context.Options.MaxDecompressedBytes);

            var decompressedSequence = new ReadOnlySequence<byte>(decompressed);
            var subReader = new SequenceReader<byte>(decompressedSequence);

            using var offsetGuard = context.SetByteOffsetBase(0);
            using var innerPathGuard = context.PushPath("{decompressed}");
            T value = _innerCodec.Decode(ref subReader, context);
            return value;
        }
        catch
        {
            context.Rewind(ref reader, checkpoint);
            throw;
        }
    }

    public void Encode(T value, IBufferWriter<byte> writer, CodecContext context)
    {

        // Stage inner encode to scratch buffer
        var scratch = context.RentScratchBuffer();
        try
        {
            _innerCodec.Encode(value, scratch, context);

            var stagedBytes = scratch.Written;
            var provider = context.Registry.GetCompressionProvider(_algorithmId);
            byte[] compressed = stagedBytes.IsSingleSegment
                ? provider.Compress(stagedBytes.FirstSpan, _level)
                : provider.Compress(stagedBytes.ToArray(), _level);

            // Write compressed length
            _compressedLengthCodec.Encode(compressed.Length, writer, context);

            // Write compressed bytes
            var span = writer.GetSpan(compressed.Length);
            compressed.AsSpan().CopyTo(span);
            writer.Advance(compressed.Length);
        }
        finally
        {
            context.ReturnScratchBuffer(scratch);
        }
    }
}

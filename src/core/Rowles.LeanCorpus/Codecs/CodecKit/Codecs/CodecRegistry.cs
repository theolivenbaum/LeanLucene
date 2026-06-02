using System;
using System.Collections.Generic;
using Rowles.LeanCorpus.Codecs.CodecKit.Checksum.Providers;
using Rowles.LeanCorpus.Codecs.CodecKit.Exceptions;
using Rowles.LeanCorpus.Codecs.CodecKit.Checksum;
using Rowles.LeanCorpus.Codecs.CodecKit.Compression;
using Rowles.LeanCorpus.Codecs.CodecKit.Compression.Providers;
using Rowles.LeanCorpus.Codecs.CodecKit.Enums;

namespace Rowles.LeanCorpus.Codecs.CodecKit.Codecs;

/// <summary>
/// Immutable registry of checksum and compression providers.
/// Use the builder pattern to register providers, then build an immutable instance.
/// </summary>
internal sealed class CodecRegistry
{
    private readonly Dictionary<ChecksumAlgorithmId, IChecksumProvider> _checksumProviders;
    private readonly Dictionary<CompressionAlgorithmId, ICompressionProvider> _compressionProviders;

    private CodecRegistry(
        Dictionary<ChecksumAlgorithmId, IChecksumProvider> checksumProviders,
        Dictionary<CompressionAlgorithmId, ICompressionProvider> compressionProviders)
    {
        _checksumProviders = checksumProviders;
        _compressionProviders = compressionProviders;
    }

    /// <summary>Creates an empty registry for building up from scratch.</summary>
    public static CodecRegistry Empty { get; } = new(
        new Dictionary<ChecksumAlgorithmId, IChecksumProvider>(),
        new Dictionary<CompressionAlgorithmId, ICompressionProvider>());

    /// <summary>
    /// Default registry pre-loaded with CRC32, xxHash32, xxHash64 checksum providers,
    /// and the Deflate compression provider.
    /// </summary>
    public static CodecRegistry Default { get; } = Empty
        .WithChecksum(ChecksumAlgorithms.Crc32, new Crc32Provider())
        .WithChecksum(ChecksumAlgorithms.XxHash32, new XxHash32Provider())
        .WithChecksum(ChecksumAlgorithms.XxHash64, new XxHash64Provider())
        .WithCompression(CompressionAlgorithms.Deflate, DeflateProvider.Instance);

    /// <summary>Looks up a checksum provider by algorithm ID.</summary>
    public IChecksumProvider GetChecksumProvider(ChecksumAlgorithmId algorithmId)
    {
        if (_checksumProviders.TryGetValue(algorithmId, out var provider))
            return provider;
        throw new InvalidValueException(CodecErrorCode.UnknownAlgorithm, 0, string.Empty,
            $"No checksum provider registered for algorithm '{algorithmId.Name}'.");
    }

    /// <summary>Looks up a compression provider by algorithm ID.</summary>
    public ICompressionProvider GetCompressionProvider(CompressionAlgorithmId algorithmId)
    {
        if (_compressionProviders.TryGetValue(algorithmId, out var provider))
            return provider;
        throw new InvalidValueException(CodecErrorCode.UnknownAlgorithm, 0, string.Empty,
            $"No compression provider registered for algorithm '{algorithmId.Name}'.");
    }

    /// <summary>Returns a new registry with an additional checksum provider.</summary>
    public CodecRegistry WithChecksum(ChecksumAlgorithmId algorithmId, IChecksumProvider provider)
    {
        var newDict = new Dictionary<ChecksumAlgorithmId, IChecksumProvider>(_checksumProviders)
        {
            [algorithmId] = provider
        };
        return new CodecRegistry(newDict, new Dictionary<CompressionAlgorithmId, ICompressionProvider>(_compressionProviders));
    }

    /// <summary>Returns a new registry with an additional compression provider.</summary>
    public CodecRegistry WithCompression(CompressionAlgorithmId algorithmId, ICompressionProvider provider)
    {
        var newDict = new Dictionary<CompressionAlgorithmId, ICompressionProvider>(_compressionProviders)
        {
            [algorithmId] = provider
        };
        return new CodecRegistry(new Dictionary<ChecksumAlgorithmId, IChecksumProvider>(_checksumProviders), newDict);
    }

}

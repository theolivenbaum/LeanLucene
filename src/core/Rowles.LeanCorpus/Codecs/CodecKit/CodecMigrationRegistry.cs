using System.Collections.Concurrent;

namespace Rowles.LeanCorpus.Codecs.CodecKit;

/// <summary>
/// Global registry of codec formats for version migration.
/// Third-party codecs call <see cref="Register"/> to add their formats;
/// <c>CodecFormats</c> consults the registry during format creation.
/// </summary>
internal sealed class CodecMigrationRegistry
{
    private readonly ConcurrentDictionary<string, CodecFormat> _formats = new(StringComparer.Ordinal);

    /// <summary>
    /// The default shared registry instance.
    /// </summary>
    public static CodecMigrationRegistry Default { get; } = new();

    /// <summary>
    /// Registers a codec format, replacing any existing entry with the same <see cref="CodecFormat.CodecId"/>.
    /// </summary>
    /// <returns>This instance for chaining.</returns>
    public CodecMigrationRegistry Register(CodecFormat format)
    {
        ArgumentNullException.ThrowIfNull(format);
        _formats[format.CodecId] = format;
        return this;
    }

    /// <summary>
    /// Gets a registered codec format by its identifier, or <c>null</c> if not found.
    /// </summary>
    public CodecFormat? Get(string codecId)
    {
        _formats.TryGetValue(codecId, out var format);
        return format;
    }
}

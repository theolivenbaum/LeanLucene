namespace Rowles.LeanCorpus.Analysis.Stemmers;

/// <summary>
/// Compatibility wrapper for <see cref="LightEnglishStemmer"/>.
/// </summary>
public sealed class KStemmer : IStemmer
{
    private readonly LightEnglishStemmer _inner = new();

    /// <inheritdoc/>
    public string Stem(string word) => _inner.Stem(word);
}

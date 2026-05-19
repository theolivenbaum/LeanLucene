namespace Rowles.LeanCorpus.Analysis.Tokenisers;

using Rowles.LeanCorpus.Analysis;
using Rowles.LeanCorpus.Analysis.Analysers;

/// <summary>
/// Splits text into character substrings of length [<see cref="MinGram"/>, <see cref="MaxGram"/>]
/// anchored at the start of each whitespace-delimited token (edge n-grams), using
/// <see cref="char.IsWhiteSpace(char)"/> for Unicode-aware whitespace detection.
///
/// Thread-safety: This class maintains an instance-level intern cache for performance.
/// Each instance should be used by a single thread, or callers should create separate instances per thread.
/// </summary>
public sealed class EdgeNGramTokeniser : ITokeniser
{
    /// <summary>
    /// Gets the minimum n-gram length (inclusive).
    /// </summary>
    public int MinGram { get; }

    /// <summary>
    /// Gets the maximum n-gram length (inclusive).
    /// </summary>
    public int MaxGram { get; }

    private const int MaxTextCacheSize = 65_536;
    private readonly TokenTextCache _textCache = new(MaxTextCacheSize);
    private readonly WhitespaceTokeniser _ws = new();
    private readonly List<(int Start, int End)> _wordOffsets = new();

    /// <summary>
    /// Initialises a new <see cref="EdgeNGramTokeniser"/> with the specified gram size range.
    /// </summary>
    /// <param name="minGram">The minimum gram length (must be ≥ 1).</param>
    /// <param name="maxGram">The maximum gram length (must be ≥ <paramref name="minGram"/>).</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="minGram"/> is less than 1, or <paramref name="maxGram"/> is less than <paramref name="minGram"/>.
    /// </exception>
    public EdgeNGramTokeniser(int minGram, int maxGram)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(minGram, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(maxGram, minGram);
        MinGram = minGram;
        MaxGram = maxGram;
    }

    /// <inheritdoc/>
    public List<Token> Tokenise(ReadOnlySpan<char> input)
    {
        var tokens = new List<Token>(CountEdgeNGrams(input));
        TokeniseCore(input, tokens);
        return tokens;
    }

    /// <summary>
    /// Tokenises the input into the supplied destination list, clearing it before use.
    /// The list's existing capacity is reused; no pre-count pass is performed.
    /// </summary>
    /// <param name="input">The text to tokenise.</param>
    /// <param name="tokens">The destination token buffer to populate.</param>
    public void Tokenise(ReadOnlySpan<char> input, List<Token> tokens)
    {
        ArgumentNullException.ThrowIfNull(tokens);
        tokens.Clear();
        TokeniseCore(input, tokens);
    }

    /// <summary>
    /// Returns a stack-only <see cref="Enumerator"/> that yields edge n-gram tokens
    /// one at a time without materialising a <see cref="List{Token}"/>.
    /// Use in a <c>foreach</c> loop when early termination or zero-list-allocation
    /// enumeration is desired.
    /// </summary>
    /// <param name="input">The text to tokenise.</param>
    public Enumerator EnumerateTokens(ReadOnlySpan<char> input) => new(this, input);

    /// <summary>
    /// Stack-only edge n-gram enumerator. Each call to <see cref="MoveNext"/> advances
    /// to the next edge n-gram. <see cref="Current"/> exposes the yielded token.
    /// </summary>
    public ref struct Enumerator
    {
        private readonly EdgeNGramTokeniser _owner;
        private readonly ReadOnlySpan<char> _input;
        private int _wordIdx;
        private int _gramLen;
        private Token _current;

        internal Enumerator(EdgeNGramTokeniser owner, ReadOnlySpan<char> input)
        {
            _owner = owner;
            _input = input;
            _wordIdx = 0;
            _gramLen = 0;
            _current = default;
            owner._ws.TokeniseOffsets(input, owner._wordOffsets);
        }

        /// <summary>Gets the current token.</summary>
        public Token Current => _current;

        /// <summary>Advances to the next edge n-gram token.</summary>
        public bool MoveNext()
        {
            while (_wordIdx < _owner._wordOffsets.Count)
            {
                var (wordStart, wordEnd) = _owner._wordOffsets[_wordIdx];
                int tokenLen = wordEnd - wordStart;
                int maxGramLen = Math.Min(_owner.MaxGram, tokenLen);

                _gramLen++;
                if (_gramLen >= _owner.MinGram && _gramLen <= maxGramLen)
                {
                    var wordSpan = _input.Slice(wordStart, maxGramLen);
                    _current = new Token(_owner._textCache.GetOrAdd(wordSpan[..(_gramLen)]), wordStart, wordStart + _gramLen);
                    return true;
                }

                if (_gramLen > maxGramLen)
                {
                    _wordIdx++;
                    _gramLen = 0;
                }
            }

            return false;
        }

        /// <summary>Returns <c>this</c> for <c>foreach</c> support.</summary>
        public Enumerator GetEnumerator() => this;
    }

    private void TokeniseCore(ReadOnlySpan<char> input, List<Token> tokens)
    {
        _ws.TokeniseOffsets(input, _wordOffsets);

        foreach (var (wordStart, wordEnd) in _wordOffsets)
        {
            int tokenLen = wordEnd - wordStart;
            int maxGramLen = Math.Min(MaxGram, tokenLen);
            var wordSpan = input.Slice(wordStart, maxGramLen);
            for (int gramLen = MinGram; gramLen <= maxGramLen; gramLen++)
            {
                tokens.Add(new Token(_textCache.GetOrAdd(wordSpan[..gramLen]), wordStart, wordStart + gramLen));
            }
        }
    }

    private int CountEdgeNGrams(ReadOnlySpan<char> input)
    {
        _ws.TokeniseOffsets(input, _wordOffsets);
        int count = 0;
        foreach (var (start, end) in _wordOffsets)
        {
            int tokenLen = end - start;
            if (tokenLen >= MinGram)
                count += Math.Min(MaxGram, tokenLen) - MinGram + 1;
        }

        return count;
    }
}

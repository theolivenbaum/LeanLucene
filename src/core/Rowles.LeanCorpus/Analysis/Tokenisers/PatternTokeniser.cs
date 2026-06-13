using System.Text.RegularExpressions;

namespace Rowles.LeanCorpus.Analysis.Tokenisers;

/// <summary>
/// Tokenises input text by splitting on a regex pattern, emitting each match as a token.
/// </summary>
/// <remarks>
/// <para>Uses <c>Regex.EnumerateMatches</c> on the input span, which is
/// allocation-free and returns a <c>ref struct</c> enumerator. Only the matched
/// spans are forwarded to the sink; the sink may choose to copy them.</para>
/// <para>Matches of zero length are skipped.</para>
/// </remarks>
public sealed class PatternTokeniser : ISpanTokeniser
{
    private readonly Regex _regex;

    /// <summary>
    /// Initialises a new <see cref="PatternTokeniser"/> with a pre-compiled <see cref="Regex"/>.
    /// </summary>
    /// <param name="regex">A regex whose matches become tokens. The regex should be
    /// compiled with appropriate options for the caller's workload.</param>
    public PatternTokeniser(Regex regex)
    {
        _regex = regex ?? throw new ArgumentNullException(nameof(regex));
    }

    /// <summary>
    /// Initialises a new <see cref="PatternTokeniser"/> from a regex pattern string.
    /// The regex is compiled with <see cref="RegexOptions.Compiled"/> and
    /// <see cref="RegexOptions.CultureInvariant"/> by default.
    /// </summary>
    /// <param name="pattern">A regular expression pattern. Each match becomes a token.</param>
    /// <param name="options">Optional regex options merged with the defaults
    /// (<see cref="RegexOptions.Compiled"/> | <see cref="RegexOptions.CultureInvariant"/>).</param>
    public PatternTokeniser(string pattern, RegexOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(pattern);

        RegexOptions merged = (options ?? RegexOptions.None)
            | RegexOptions.Compiled
            | RegexOptions.CultureInvariant;

        _regex = new Regex(pattern, merged);
    }

    /// <inheritdoc/>
    public void Tokenise(ReadOnlySpan<char> input, ISpanTokenSink sink)
    {
        ArgumentNullException.ThrowIfNull(sink);

        // Regex.EnumerateMatches on ReadOnlySpan<char> returns a ref struct enumerator
        // — zero heap allocation.
        foreach (ValueMatch match in _regex.EnumerateMatches(input))
        {
            if (match.Length == 0)
                continue;

            ReadOnlySpan<char> tokenText = input.Slice(match.Index, match.Length);
            sink.Add(
                tokenText,
                match.Index,
                match.Index + match.Length,
                Token.DefaultType,
                positionIncrement: 1);
        }
    }
}

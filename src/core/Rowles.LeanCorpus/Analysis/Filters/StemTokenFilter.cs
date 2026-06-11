using System.Buffers;
using Rowles.LeanCorpus.Analysis.Stemmers;

namespace Rowles.LeanCorpus.Analysis.Filters;

/// <summary>
/// Applies an <see cref="ISpanStemmer"/> to each token in the list.
/// Useful as a drop-in filter in the composable <see cref="Analysers.Analyser"/> pipeline.
/// </summary>
public sealed class StemTokenFilter : ISpanTokenFilter
{
    private readonly ISpanStemmer _stemmer;

    /// <summary>
    /// Initialises a new <see cref="StemTokenFilter"/>.
    /// </summary>
    public StemTokenFilter(ISpanStemmer stemmer)
    {
        _stemmer = stemmer ?? throw new ArgumentNullException(nameof(stemmer));
    }

    /// <inheritdoc/>
    public void Apply(
        ReadOnlySpan<char> text,
        int startOffset,
        int endOffset,
        string type,
        int positionIncrement,
        byte[]? payload,
        ISpanTokenSink sink)
    {
        ArgumentNullException.ThrowIfNull(sink);

        const int StackThreshold = 128;
        char[]? rented = null;
        try
        {
            Span<char> buf = text.Length <= StackThreshold
                ? stackalloc char[text.Length]
                : (rented = ArrayPool<char>.Shared.Rent(text.Length)).AsSpan(0, text.Length);

            int len = _stemmer.Stem(text, buf);

            if (len == text.Length && buf[..len].SequenceEqual(text))
            {
                sink.Add(text, startOffset, endOffset, type, positionIncrement, payload);
            }
            else
            {
                sink.Add(buf[..len], startOffset, endOffset, type, positionIncrement, payload);
            }
        }
        finally
        {
            if (rented is not null) ArrayPool<char>.Shared.Return(rented);
        }
    }

}

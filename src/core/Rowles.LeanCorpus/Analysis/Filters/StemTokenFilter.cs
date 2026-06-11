using System.Buffers;
using Rowles.LeanCorpus.Analysis.Stemmers;

namespace Rowles.LeanCorpus.Analysis.Filters;

/// <summary>
/// Applies an <see cref="IStemmer"/> to each token in the list.
/// Useful as a drop-in filter in the composable <see cref="Analysers.Analyser"/> pipeline.
/// </summary>
public sealed class StemTokenFilter : ISpanTokenFilter
{
    private readonly IStemmer _stemmer;

    /// <summary>
    /// Initialises a new <see cref="StemTokenFilter"/>.
    /// </summary>
    public StemTokenFilter(IStemmer stemmer)
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

        if (_stemmer is ISpanStemmer spanStemmer)
        {
            const int StackThreshold = 128;
            char[]? rented = null;
            try
            {
                Span<char> buf = text.Length <= StackThreshold
                    ? stackalloc char[text.Length]
                    : (rented = ArrayPool<char>.Shared.Rent(text.Length)).AsSpan(0, text.Length);

                int len = spanStemmer.Stem(text, buf);

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
        else
        {
            var stemmed = _stemmer.Stem(new string(text));
            sink.Add(stemmed.AsSpan(), startOffset, endOffset, type, positionIncrement, payload);
        }
    }

}

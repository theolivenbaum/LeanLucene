namespace Rowles.LeanCorpus.Search.Scoring;

/// <summary>
/// A simple count-only collector that tracks hit count without storing results.
/// Useful for count queries where actual documents are not needed.
/// </summary>
public sealed class CountCollector : ICollector
{
    private int _totalHits;

    /// <inheritdoc/>
    public int TotalHits => Volatile.Read(ref _totalHits);

    /// <inheritdoc/>
    public void Collect(int docId, float score) => Interlocked.Increment(ref _totalHits);
}

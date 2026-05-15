namespace Rowles.LeanCorpus.Search.Searcher;

public sealed partial class IndexSearcher
{
    private static float ApplyFieldBoost(SegmentReader reader, int docId, string field, float score)
    {
        float fieldBoost = reader.GetFieldBoost(docId, field);
        return fieldBoost != 1.0f ? score * fieldBoost : score;
    }
}

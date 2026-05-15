using Rowles.LeanCorpus.Analysis.Stemmers;

namespace Rowles.LeanCorpus.Tests.Unit.Analysis;

[Trait("Category", "Analysis")]
public sealed class KStemmerTests
{
    [Theory(DisplayName = "KStemmer: Common English Inflections Stem Predictably")]
    [InlineData("running", "run")]
    [InlineData("jumped", "jump")]
    [InlineData("skies", "sky")]
    [InlineData("news", "news")]
    public void KStemmer_CommonEnglishInflections_StemPredictably(string input, string expected)
    {
        var stemmer = new KStemmer();

        var actual = stemmer.Stem(input);

        Assert.Equal(expected, actual);
    }
}

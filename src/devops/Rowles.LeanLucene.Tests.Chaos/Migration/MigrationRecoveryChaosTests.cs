using Rowles.LeanLucene.Index.Migration;
using Rowles.LeanLucene.Tests.Chaos.Infrastructure;

namespace Rowles.LeanLucene.Tests.Chaos.Migration;

[Trait("Category", "Chaos")]
[Trait("Category", "Migration")]
public sealed class MigrationRecoveryChaosTests : IClassFixture<ChaosDirectoryFixture>
{
    private readonly ChaosDirectoryFixture _fixture;

    public MigrationRecoveryChaosTests(ChaosDirectoryFixture fixture) => _fixture = fixture;

    [Fact]
    public void RollBack_PreparedMarker_DeletesStagingAndClearsMarker()
    {
        var sourcePath = System.IO.Path.Combine(_fixture.Path, "rollback_source");
        var stagingPath = System.IO.Path.Combine(_fixture.Path, "rollback_staging");
        Directory.CreateDirectory(sourcePath);
        Directory.CreateDirectory(stagingPath);
        File.WriteAllText(System.IO.Path.Combine(stagingPath, "leftover.tmp"), "pending migration data");
        IndexMigrationRecovery.WriteMarker(sourcePath, CreateMarker(IndexMigrationState.Prepared, sourcePath, stagingPath), durable: false);

        IndexMigrationRecovery.RollBack(sourcePath);

        Assert.False(Directory.Exists(stagingPath));
        Assert.False(File.Exists(System.IO.Path.Combine(sourcePath, IndexMigrationRecovery.MarkerFileName)));
        Assert.Equal(IndexMigrationState.None, IndexMigrationRecovery.GetState(sourcePath).State);
    }

    [Fact]
    public void GetState_CorruptMarker_ThrowsInvalidDataException()
    {
        var sourcePath = System.IO.Path.Combine(_fixture.Path, "corrupt_marker");
        Directory.CreateDirectory(sourcePath);
        File.WriteAllText(System.IO.Path.Combine(sourcePath, IndexMigrationRecovery.MarkerFileName), "{ not-json");

        Assert.Throws<InvalidDataException>(() => IndexMigrationRecovery.GetState(sourcePath));
    }

    private static IndexMigrationMarker CreateMarker(IndexMigrationState state, string sourcePath, string stagingPath)
    {
        var now = DateTimeOffset.UtcNow;
        return new IndexMigrationMarker
        {
            State = state,
            SourceDirectory = sourcePath,
            StagingDirectory = stagingPath,
            SourceCommitGeneration = 1,
            CreatedAtUtc = now,
            UpdatedAtUtc = now,
            PlannedActions = []
        };
    }
}

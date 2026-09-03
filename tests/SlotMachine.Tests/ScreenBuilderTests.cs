using SlotMachine.Config;
using SlotMachine.Engine;

namespace SlotMachine.Tests;

public class ScreenBuilderTests
{
    [Fact]
    public void Build_MatchFirstAssignmentScreenFromStopPositions()
    {
        var config = GameConfigLoader.LoadFromFile("Config/slot-config.json");
        var builder = new ScreenBuilder();

        var screen = builder.BuildScreen(config, [18, 9, 2, 0, 12]);

        Assert.Equal("sym7", screen.GetSymbol(0, 0));
        Assert.Equal("sym4", screen.GetSymbol(0, 1));
        Assert.Equal("sym7", screen.GetSymbol(0, 2));
        Assert.Equal("sym2", screen.GetSymbol(0, 3));
        Assert.Equal("sym6", screen.GetSymbol(0, 4));

        Assert.Equal("sym2", screen.GetSymbol(1, 0));
        Assert.Equal("sym7", screen.GetSymbol(1, 1));
        Assert.Equal("sym8", screen.GetSymbol(1, 2));
        Assert.Equal("sym6", screen.GetSymbol(1, 3));
        Assert.Equal("sym4", screen.GetSymbol(1, 4));

        Assert.Equal("sym2", screen.GetSymbol(2, 0));
        Assert.Equal("sym2", screen.GetSymbol(2, 1));
        Assert.Equal("sym3", screen.GetSymbol(2, 2));
        Assert.Equal("sym3", screen.GetSymbol(2, 3));
        Assert.Equal("sym1", screen.GetSymbol(2, 4));
    }

    [Fact]
    public void Build_WrapsAroundReelBandEnd()
    {
        var config = new GameConfig
        {
            Rows = 3,
            ReelBands = [["a", "b", "c"]],
            Paytable = new Dictionary<string, IReadOnlyDictionary<int, int>>()
        };

        var builder = new ScreenBuilder();
        var screen = builder.BuildScreen(config, [2]);

        Assert.Equal("c", screen.GetSymbol(0, 0));
        Assert.Equal("a", screen.GetSymbol(1, 0));
        Assert.Equal("b", screen.GetSymbol(2, 0));
    }

    [Fact]
    public void Build_WrapsAroundReelBandEndForTheActualConfig()
    {
        var config = GameConfigLoader.LoadFromFile("Config/slot-config.json");
        var builder = new ScreenBuilder();

        var screen = builder.BuildScreen(config, [19, 24, 29, 24, 19]);

        Assert.Equal("sym2", screen.GetSymbol(1, 0));
        Assert.Equal("sym1", screen.GetSymbol(1, 1));
        Assert.Equal("sym5", screen.GetSymbol(1, 2));
        Assert.Equal("sym2", screen.GetSymbol(1, 3));
        Assert.Equal("sym7", screen.GetSymbol(1, 4));
    }

    [Fact]
    public void Build_ErrorWhenStopPositionsCountDoesNotMatchReels()
    {
        var config = GameConfigLoader.LoadFromFile("Config/slot-config.json");
        var builder = new ScreenBuilder();

        Assert.Throws<ArgumentException>(() => builder.BuildScreen(config, [18, 9, 2]));
    }

    [Fact]
    public void Build_ErrorWhenStopPositionDoesNotIncludedIntoReelBandRange()
    {
        var config = GameConfigLoader.LoadFromFile("Config/slot-config.json");
        var builder = new ScreenBuilder();

        Assert.Throws<ArgumentOutOfRangeException>(() => builder.BuildScreen(config, [25, 9, 2, 0, 12]));
    }
}

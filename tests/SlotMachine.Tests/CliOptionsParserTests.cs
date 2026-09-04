using SlotMachine.Cli;

namespace SlotMachine.Tests;

public class CliOptionsParserTests
{
    [Fact]
    public void Parse_RandomSpinIfArgumentsWerentPass()
    {
        var options = CliOptionsParser.Parse([]);

        Assert.Null(options.StopPositions);
    }

    [Fact]
    public void Parse_ReturnStopPositions()
    {
        var options = CliOptionsParser.Parse(["--stops", "0", "11", "1", "10", "14"]);

        Assert.Equal([0, 11, 1, 10, 14], options.StopPositions);
    }

    [Fact]
    public void Parse_ErrorWhenArgumentIsUnknown()
    {
        Assert.Throws<ArgumentException>(() => CliOptionsParser.Parse(["--arg", "1"]));
    }

    [Fact]
    public void Parse_ErrorWhenStopPositionIsNotNumber()
    {
        Assert.Throws<FormatException>(() => CliOptionsParser.Parse(["--stops", "1", "r"]));
    }
}

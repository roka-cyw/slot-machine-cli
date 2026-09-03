using SlotMachine.Config;
using SlotMachine.Engine;
using SlotMachine.Models;

namespace SlotMachine.Tests;

public class WaysWinCalculatorTests
{
    [Fact]
    public void Calculate_MatchFirstAssignmentWinningCase()
    {
        var config = GameConfigLoader.LoadFromFile("Config/slot-config.json");
        var builder = new ScreenBuilder();
        var calculator = new WaysWinCalculator();

        var screen = builder.BuildScreen(config, [0, 11, 1, 10, 14]);
        var paytable = new PayTable
        {
            Payouts = config.Paytable
        };

        var wins = calculator.Calculate(screen, paytable);

        Assert.Equal(11, wins.Sum(win => win.Payout));
        Assert.Equal(3, wins.Count);

        Assert.Equal([0, 1, 2], wins[0].Positions);
        Assert.Equal("sym2", wins[0].Symbol);
        Assert.Equal(3, wins[0].MatchCount);
        Assert.Equal(1, wins[0].Payout);

        Assert.Equal([5, 11, 7], wins[1].Positions);
        Assert.Equal("sym7", wins[1].Symbol);
        Assert.Equal(3, wins[1].MatchCount);
        Assert.Equal(5, wins[1].Payout);

        Assert.Equal([10, 11, 7], wins[2].Positions);
        Assert.Equal("sym7", wins[2].Symbol);
        Assert.Equal(3, wins[2].MatchCount);
        Assert.Equal(5, wins[2].Payout);
    }

    [Fact]
    public void Calculate_MatchSecondAssignmentWinningCase()
    {
        var config = GameConfigLoader.LoadFromFile("Config/slot-config.json");
        var builder = new ScreenBuilder();
        var calculator = new WaysWinCalculator();

        var screen = builder.BuildScreen(config, [4, 6, 15, 21, 9]);
        var paytable = new PayTable
        {
            Payouts = config.Paytable
        };

        var wins = calculator.Calculate(screen, paytable);

        Assert.Equal(0, wins.Sum(win => win.Payout));
        Assert.Empty(wins);
    }

    [Fact]
    public void Calculate_MatchThirdAssignmentWinningCase()
    {
        var config = GameConfigLoader.LoadFromFile("Config/slot-config.json");
        var builder = new ScreenBuilder();
        var calculator = new WaysWinCalculator();

        var screen = builder.BuildScreen(config, [9, 11, 14, 4, 9]);
        var paytable = new PayTable
        {
            Payouts = config.Paytable
        };

        var wins = calculator.Calculate(screen, paytable);

        Assert.Equal(1, wins.Sum(win => win.Payout));
        Assert.Single(wins);

        Assert.Equal([5, 1, 7], wins[0].Positions);
        Assert.Equal("sym2", wins[0].Symbol);
        Assert.Equal(3, wins[0].MatchCount);
        Assert.Equal(1, wins[0].Payout);
    }

    [Fact]
    public void Calculate_MatchFourthAssignmentWinningCase()
    {
        var config = GameConfigLoader.LoadFromFile("Config/slot-config.json");
        var builder = new ScreenBuilder();
        var calculator = new WaysWinCalculator();

        var screen = builder.BuildScreen(config, [9, 16, 22, 14, 8]);
        var paytable = new PayTable
        {
            Payouts = config.Paytable
        };

        var wins = calculator.Calculate(screen, paytable);

        Assert.Equal(0, wins.Sum(win => win.Payout));
        Assert.Empty(wins);
    }

    [Fact]
    public void Calculate_MatchFifthAssignmentWinningCase()
    {
        var config = GameConfigLoader.LoadFromFile("Config/slot-config.json");
        var builder = new ScreenBuilder();
        var calculator = new WaysWinCalculator();

        var screen = builder.BuildScreen(config, [2, 5, 9, 10, 12]);
        var paytable = new PayTable
        {
            Payouts = config.Paytable
        };

        var wins = calculator.Calculate(screen, paytable);

        Assert.Equal(0, wins.Sum(win => win.Payout));
        Assert.Empty(wins);
    }

    [Fact]
    public void Calculate_MatchSixthAssignmentWinningCase()
    {
        var config = GameConfigLoader.LoadFromFile("Config/slot-config.json");
        var builder = new ScreenBuilder();
        var calculator = new WaysWinCalculator();

        var screen = builder.BuildScreen(config, [3, 4, 9, 23, 1]);
        var paytable = new PayTable
        {
            Payouts = config.Paytable
        };

        var wins = calculator.Calculate(screen, paytable);

        Assert.Equal(40, wins.Sum(win => win.Payout));
        Assert.Equal(4, wins.Count);

        Assert.Equal([10, 1, 2, 3], wins[0].Positions);
        Assert.Equal("sym5", wins[0].Symbol);
        Assert.Equal(4, wins[0].MatchCount);
        Assert.Equal(10, wins[0].Payout);

        Assert.Equal([10, 1, 12, 3], wins[1].Positions);
        Assert.Equal("sym5", wins[1].Symbol);
        Assert.Equal(4, wins[1].MatchCount);
        Assert.Equal(10, wins[1].Payout);

        Assert.Equal([10, 6, 2, 3], wins[2].Positions);
        Assert.Equal("sym5", wins[2].Symbol);
        Assert.Equal(4, wins[2].MatchCount);
        Assert.Equal(10, wins[2].Payout);

        Assert.Equal([10, 6, 12, 3], wins[3].Positions);
        Assert.Equal("sym5", wins[3].Symbol);
        Assert.Equal(4, wins[3].MatchCount);
        Assert.Equal(10, wins[3].Payout);
    }
}

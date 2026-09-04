using SlotMachine.Config;
using SlotMachine.Models;

namespace SlotMachine.Engine;

public sealed class SlotGameEngine
{
    private readonly ScreenBuilder _screenBuilder;
    private readonly WaysWinCalculator _winsCalculator;

    public SlotGameEngine(ScreenBuilder screenBuilder, WaysWinCalculator waysWinCalculator)
    {
        _screenBuilder = screenBuilder;
        _winsCalculator = waysWinCalculator;
    }

    public SpinResult Spin(GameConfig config, IReadOnlyList<int> stopPositions)
    {
        var screen = _screenBuilder.BuildScreen(config, stopPositions);

        var paytable = new PayTable
        {
            Payouts = config.Paytable
        };

        var wins = _winsCalculator.Calculate(screen, paytable);

        return new SpinResult
        {
            StopPositions = stopPositions,
            Screen = screen,
            Wins = wins
        };
    }
}
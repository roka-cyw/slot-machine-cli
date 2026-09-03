using SlotMachine.Models;

namespace SlotMachine.Engine;

public sealed class WaysWinCalculator
{
    public IReadOnlyList<WayWin> Calculate(SlotScreen screen, PayTable paytable)
    {
        var wins = new List<WayWin>();
        var checkedSymbols = new HashSet<string>();

        for (var row = 0; row < screen.Rows; row++)
        {
            var symbolForWays = screen.GetSymbol(row, 0);

            if (!checkedSymbols.Add(symbolForWays))
                continue;

            var positionsByColumn = GetMatchingPositionsByColumn(screen, symbolForWays);
            var matchCount = positionsByColumn.Count;

            if (!paytable.GetPayout(symbolForWays, matchCount, out var payout))
                continue;

            AddWays(wins, positionsByColumn, symbolForWays, matchCount, payout, [], 0);
        }

        return wins;
    }

    // Assignment case #1: Ways symbols are sym2 and sym7
    // For the sym7 we have [[5, 10], [11], [7]] positions
    private static List<IReadOnlyList<int>> GetMatchingPositionsByColumn(SlotScreen screen,
        string symbol)
    {
        var positionsByColumn = new List<IReadOnlyList<int>>();

        for (var column = 0; column < screen.Columns; column++)
        {
            var positions = new List<int>();

            for (var row = 0; row < screen.Rows; row++)
            {
                if (screen.GetSymbol(row, column) == symbol)
                    positions.Add(row * screen.Columns + column);
            }

            if (positions.Count == 0)
                break;

            positionsByColumn.Add(positions);
        }

        return positionsByColumn;
    }
    private static void AddWays(List<WayWin> wins, IReadOnlyList<IReadOnlyList<int>> positionsByColumn, string symbol, int matchCount, int payout, List<int> currentPositions, int column)
    {
        if (column == positionsByColumn.Count)
        {
            wins.Add(new WayWin
            {
                Positions = currentPositions.ToArray(),
                Symbol = symbol,
                MatchCount = matchCount,
                Payout = payout,
            });

            return;
        }

        foreach (var position in positionsByColumn[column])
        {
            currentPositions.Add(position);
            AddWays(wins, positionsByColumn, symbol, matchCount, payout, currentPositions, column + 1);
            currentPositions.RemoveAt(currentPositions.Count - 1);
        }
    }
}
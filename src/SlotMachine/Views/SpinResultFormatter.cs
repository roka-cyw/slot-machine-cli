using SlotMachine.Models;

namespace SlotMachine.Views;

public static class SpinResultFormatter
{
    public static string Format(SpinResult result)
    {
        var outputLines = new List<string>
        {
            $"Stop Positions: {string.Join(", ", result.StopPositions)}",
            "Screen:"
        };

        for (var row = 0; row < result.Screen.Rows; row++)
        {
            var symbols = new List<string>();

            for (var column = 0; column < result.Screen.Columns; column++)
                symbols.Add(result.Screen.GetSymbol(row, column));

            outputLines.Add($"  {string.Join(' ', symbols)}");
        }

        outputLines.Add($"Total wins: {result.TotalWin}");

        foreach (var win in result.Wins)
            outputLines.Add($"- Ways win {string.Join('-', win.Positions)}, {win.Symbol} x{win.MatchCount}, {win.Payout}");

        return string.Join(Environment.NewLine, outputLines);
    }
}
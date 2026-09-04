using SlotMachine.Config;
using SlotMachine.Models;

namespace SlotMachine.Engine;

public sealed class ScreenBuilder
{
    public SlotScreen BuildScreen(GameConfig config, IReadOnlyList<int> stopPositions)
    {
        if (stopPositions.Count != config.ReelBands.Count)
            throw new ArgumentException("Stop positions count must be equal to reel count!", nameof(stopPositions));

        var configColumns = config.ReelBands.Count;
        var symbols = new List<string>();

        // Check if stop position is correct
        for (var column = 0; column < configColumns; column++)
        {
            var reelBand = config.ReelBands[column];
            var stopPosition = stopPositions[column];

            if (stopPosition < 0 || stopPosition >= reelBand.Count)
                throw new ArgumentOutOfRangeException(nameof(stopPositions), "Stop position is outside of the actual reelband range!");
        }

        // create symbols list for SlotScreen
        for (var row = 0; row < config.Rows; row++)
        {
            for (var column = 0; column < configColumns; column++)
            {
                var reelBand = config.ReelBands[column];
                var symbolIndex = (stopPositions[column] + row) % reelBand.Count;

                symbols.Add(reelBand[symbolIndex]);
            }
        }

        return new SlotScreen
        {
            Rows = config.Rows,
            Columns = configColumns,
            Symbols = symbols
        };
    }
}
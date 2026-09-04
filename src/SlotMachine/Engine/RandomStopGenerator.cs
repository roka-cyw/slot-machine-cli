using SlotMachine.Config;

namespace SlotMachine.Engine;

public sealed class RandomStopGenerator
{
    private readonly Random _random = new Random();
    public IReadOnlyList<int> Generate(GameConfig config)
    {
        return config.ReelBands.Select(reelBand => _random.Next(reelBand.Count)).ToList();
    }
}
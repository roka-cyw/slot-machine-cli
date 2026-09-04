namespace SlotMachine.Models;

public sealed class WayWin
{
    public required IReadOnlyList<int> Positions { get; init; }
    public required string Symbol { get; init; }
    public required int MatchCount { get; init; }
    public required int Payout { get; init; }
}
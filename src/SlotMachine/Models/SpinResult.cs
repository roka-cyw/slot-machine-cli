namespace SlotMachine.Models;

public sealed class SpinResult
{
    public required IReadOnlyList<int> StopPositions { get; init; }
    public required SlotScreen Screen { get; init; }
    public required IReadOnlyList<WayWin> Wins { get; init; }
    public int TotalWin => Wins.Sum(win => win.Payout);
}
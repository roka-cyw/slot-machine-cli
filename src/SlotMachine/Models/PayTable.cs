namespace SlotMachine.Models;

public sealed class PayTable
{
    public required IReadOnlyDictionary<string, IReadOnlyDictionary<int, int>> Payouts { get; init; }
    public bool TryGetPayout(string symbol, int matchCount, out int payout)
    {
        if (Payouts.TryGetValue(symbol, out var symbolPayouts) &&
            symbolPayouts.TryGetValue(matchCount, out payout))
        {
            return true;
        }

        payout = 0;
        return false;
    }
}
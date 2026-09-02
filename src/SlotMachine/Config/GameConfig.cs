namespace SlotMachine.Config;

public sealed class GameConfig
{
    public required int Rows { get; init; }
    public required IReadOnlyList<IReadOnlyList<string>> ReelBands { get; init; }
    public required IReadOnlyDictionary<string, IReadOnlyDictionary<int, int>> Paytable { get; init; }
}
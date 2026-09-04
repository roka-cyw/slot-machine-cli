namespace SlotMachine.Config;

internal sealed class GameConfigDto
{
    public int Rows { get; set; }
    public List<List<string>> ReelBands { get; set; } = [];
    public Dictionary<string, Dictionary<int, int>> Paytable { get; set; } = [];
}
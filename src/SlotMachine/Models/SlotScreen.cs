namespace SlotMachine.Models;

public sealed class SlotScreen
{
    public required int Rows { get; init; }
    public required int Columns { get; init; }
    public required IReadOnlyList<string> Symbols { get; init; }

    public string GetSymbol(int row, int column)
    {
        return Symbols[row * Columns + column];
    }
}
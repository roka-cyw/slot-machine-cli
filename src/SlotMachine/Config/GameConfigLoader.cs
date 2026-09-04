using System.Text.Json;

namespace SlotMachine.Config;

public static class GameConfigLoader
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    public static GameConfig LoadFromFile(string path)
    {
        var json = File.ReadAllText(path);
        var dto = JsonSerializer.Deserialize<GameConfigDto>(json, JsonOptions)
            ?? throw new InvalidOperationException("Slot config is incorrect!");

        return new GameConfig
        {
            Rows = dto.Rows,
            ReelBands = dto.ReelBands,
            Paytable = dto.Paytable.ToDictionary(
                entry => entry.Key,
                entry => (IReadOnlyDictionary<int, int>)entry.Value)
        };
    }
}
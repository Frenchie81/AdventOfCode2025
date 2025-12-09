using System.Text.Json;

namespace AdventOfCode2025;

public static class Helpers
{
    private static readonly JsonSerializerOptions JSON_OPTIONS = new() { WriteIndented = true };

    public static void ToConsole(this object obj)
    {
        Console.WriteLine(JsonSerializer.Serialize(obj, JSON_OPTIONS));
    }
}

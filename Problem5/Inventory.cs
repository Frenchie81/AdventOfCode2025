using System.Text.Json;

namespace AdventOfCode2025.Problem5;

public class Inventory
{
    public static Inventory Parse(string content)
    {
        var inventory = new Inventory();
        var parsingRanges = true;
        foreach (var line in content.EnumerateLines())
        {
            if (string.IsNullOrWhiteSpace(line.ToString()))
            {
                parsingRanges = false;
                continue;
            }

            if (parsingRanges)
            {
                var splits = line.ToString().Split('-');
                var start = long.Parse(splits[0]);
                var end = long.Parse(splits[1]);
                inventory.Ranges.Add(new Range(start, end));
            }
            else
            {
                var product = long.Parse(line.ToString());
                inventory.Products.Add(product);
            }
        }

        return inventory;
    }

    private Inventory() { }

    public List<Range> Ranges { get; private set; } = [];

    public List<long> Products { get; private set; } = [];

    public long CountFreshIngredients()
    {
        long count = 0;

        foreach (var product in Products)
        {
            if (Ranges.Any(r => r.IsInRange(product)))
            {
                count += 1;
            }
        }

        return count;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}

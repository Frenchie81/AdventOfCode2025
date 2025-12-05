using System.Text.Json;

namespace AdventOfCode2025.Problem5;

public class Inventory
{
    public static Inventory Parse(string content)
    {
        var inventory = new Inventory();
        var parsingRanges = true;
        var ranges = new List<Range>();
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
                ranges.Add(new Range(start, end));
            }
            else
            {
                var product = long.Parse(line.ToString());
                inventory.Products.Add(product);
            }
        }

        foreach (var range in ranges.OrderBy(r => r.Start).ThenBy(r => r.End))
        {
            inventory.AddRange(range);
        }

        return inventory;
    }

    private Inventory() { }

    public List<Range> Ranges { get; private set; } = [];

    public List<long> Products { get; private set; } = [];

    public long CountFreshProducts()
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

    public long CountFreshIngredients()
    {
        return Ranges.Sum(r => r.RangeTotal());
    }

    public void AddRange(Range range)
    {
        if (Ranges.Any(r => r.TryCollapse(range)))
        {
            return;
        }

        Ranges.AddRange(range);
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}

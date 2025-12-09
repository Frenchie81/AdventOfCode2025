namespace AdventOfCode2025.Problem9;

public class Problem9
{
    public record Tile(long X, long Y);

    private static List<Tile> Parse(string content)
    {
        var list = new List<Tile>();

        foreach (var line in content.EnumerateLines())
        {
            var splits = line.ToString().Split(',');
            list.Add(new Tile(long.Parse(splits[0]), long.Parse(splits[1])));
        }

        return list;
    }

    private static long CalculateArea(Tile a, Tile b)
    {
        var deltaX = Math.Abs(a.X - b.X);
        var deltaY = Math.Abs(a.Y - b.Y);

        var area = (deltaX + 1) * (deltaY + 1);

        return area;
    }

    private static long Solve(string content)
    {
        var tiles = Parse(content);
        long max = 0;

        for (var i = 0; i < tiles.Count; i++)
        {
            var tileA = tiles[i];
            for (var j = i + 1; j < tiles.Count; j++)
            {
                var tileB = tiles[j];
                var area = CalculateArea(tileA, tileB);
                if (area > max)
                {
                    max = area;
                }
            }
        }

        return max;
    }

    [Fact]
    public void Example()
    {
        var result = Solve(Content.EXAMPLE);

        Assert.Equal(50, result);
    }

    [Fact]
    public void File()
    {
        var result = Solve(Content.FILE);

        Assert.Equal(4750176210, result);
    }
}

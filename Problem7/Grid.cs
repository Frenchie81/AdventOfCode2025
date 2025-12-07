using System.Text;

namespace AdventOfCode2025.Problem7;

public class Grid
{
    public Grid(string content)
    {
        Tiles = [];
        int y = 0;
        int startX = 0;
        int startY = 0;
        foreach (var line in content.EnumerateLines())
        {
            var row = new List<Tile>();
            int x = 0;
            foreach (var c in line)
            {
                var tile = Tile.Open;
                if (c == '^')
                {
                    tile = Tile.Splitter;
                }
                row.Add(tile);
                if (c == 'S')
                {
                    startX = x;
                    startY = y;
                }

                x++;
            }

            Tiles.Add(row);
            y++;
        }

        MaxX = Tiles[0].Count - 1;
        MaxY = Tiles.Count - 1;
        StartX = startX;
        StartY = startY;
    }

    public int StartX { get; private set; }

    public int StartY { get; private set; }

    public List<List<Tile>> Tiles { get; private set; }

    public int SplitCount { get; set; } = 0;

    public long TimelineCount { get; set; } = 0;

    public int MaxX { get; private set; }

    public int MaxY { get; private set; }

    public Tile GetTile(int x, int y)
    {
        if (x < 0 || y < 0 || x > MaxX || y > MaxY)
        {
            return Tile.OutOfBounds;
        }

        return Tiles[y][x];
    }

    public void Run()
    {
        TimelineCount = Recurse(StartX, StartY, []);
    }

    public long Recurse(int nextX, int nextY, Dictionary<(int x, int y), long> memo)
    {
        if (memo.TryGetValue((nextX, nextY), out var memoValue))
        {
            return memoValue;
        }

        long count = 0;
        var tile = GetTile(nextX, nextY);
        switch (tile)
        {
            case Tile.Open:
                count += Recurse(nextX, nextY + 1, memo);
                break;
            case Tile.Splitter:
                SplitCount += 1;
                count += Recurse(nextX - 1, nextY + 1, memo);
                count += Recurse(nextX + 1, nextY + 1, memo);
                break;
            case Tile.OutOfBounds:
                count += 1;
                break;
            default:
                break;
        }

        memo.Add((nextX, nextY), count);
        return count;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var line in Tiles)
        {
            foreach (var tile in line)
            {
                switch (tile)
                {
                    case Tile.Splitter:
                        sb.Append('^');
                        break;
                    case Tile.Open:
                        sb.Append('.');
                        break;
                    case Tile.Beam:
                        sb.Append('|');
                        break;
                    case Tile.OutOfBounds:
                        break;
                    default:
                        break;
                }
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }
}

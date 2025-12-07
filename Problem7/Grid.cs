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

        Beams.Add(new Beam(this, startX, startY));
    }

    public List<List<Tile>> Tiles { get; private set; }

    public List<Beam> Beams { get; } = [];

    public int SplitCount { get; set; } = 0;

    public long TimelineCount { get; set; } = 0;

    public int MaxX { get; private set; }

    public int MaxY { get; private set; }

    public void SetTile(int x, int y, Tile tile)
    {
        Tiles[y][x] = tile;
    }

    public Tile GetTile(int x, int y)
    {
        if (x < 0 || y < 0 || x > MaxX || y > MaxY)
        {
            return Tile.OutOfBounds;
        }

        return Tiles[y][x];
    }

    public bool AddBeam(int x, int y, bool ignoreExistingBeam = false)
    {
        var tile = GetTile(x, y);
        if (tile == Tile.Open || (ignoreExistingBeam && tile == Tile.Beam))
        {
            Beams.Add(new Beam(this, x, y));
            return true;
        }
        return false;
    }

    public void Move()
    {
        var beams = Beams.Where(b => !b.Finished).ToList();

        foreach (var beam in beams)
        {
            beam.Move();
        }
    }

    public void Move2()
    {
        var beams = Beams.Where(b => !b.Finished).ToList();

        foreach (var beam in beams)
        {
            beam.Move2();
        }
    }

    public int CountTimelines()
    {
        var count = -1;
        foreach (var row in Tiles)
        {
            count += row.Count(t => t == Tile.Beam);
        }
        return count;
    }

    public void Run()
    {
        while (Beams.Any(b => !b.Finished))
        {
            Move();
        }
    }

    public void Run2()
    {
        var start = Beams.First();
        TimelineCount = Recurse(start.X, start.Y + 1, []);
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

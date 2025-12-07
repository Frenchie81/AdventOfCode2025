namespace AdventOfCode2025.Problem7;

public class Beam
{
    public Beam(Grid grid, int x, int y)
    {
        Grid = grid;
        X = x;
        Y = y;
        if (Grid.GetTile(x, y) != Tile.Open)
        {
            throw new Exception("invalid tile");
        }

        Grid.SetTile(x, y, Tile.Beam);
    }

    public int X { get; set; }

    public int Y { get; set; }

    public Grid Grid { get; private set; }

    public bool Finished { get; private set; } = false;

    public void Move()
    {
        var nextY = Y + 1;
        var tile = Grid.GetTile(X, nextY);
        switch (tile)
        {
            case Tile.Open:
                Y = nextY;
                Grid.SetTile(X, Y, Tile.Beam);
                break;
            case Tile.Splitter:
                Grid.SplitCount += 1;
                Grid.AddBeam(X + 1, nextY);
                Grid.AddBeam(X - 1, nextY);
                Finished = true;
                break;
            case Tile.Beam:
                Finished = true;
                break;
            case Tile.OutOfBounds:
                Finished = true;
                break;
        }
    }

    public void Move2()
    {
        var nextY = Y + 1;
        var tile = Grid.GetTile(X, nextY);
        switch (tile)
        {
            case Tile.Open:
                Y = nextY;
                Grid.SetTile(X, Y, Tile.Beam);
                break;
            case Tile.Splitter:
                Grid.SplitCount += 1;
                Grid.AddBeam(X + 1, nextY);
                Grid.AddBeam(X - 1, nextY);
                Finished = true;
                break;
            case Tile.Beam:
                Finished = true;
                break;
            case Tile.OutOfBounds:
                Finished = true;
                break;
        }
    }

    public override string ToString()
    {
        return $"Beam X={X} Y={Y} Finished={Finished}";
    }
}

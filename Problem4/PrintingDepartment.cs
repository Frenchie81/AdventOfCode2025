namespace AdventOfCode2025.Problem4;

public class PrintingDepartment
{
    public PrintingDepartment(string content)
    {
        var grid = new List<List<char>>();
        foreach (var line in content.EnumerateLines())
        {
            var row = new List<char>(line.ToArray());
            grid.Add(row);
        }

        Grid = grid;
    }

    public List<List<char>> Grid { get; private set; }

    public List<(int Y, int X)> GetRollsToRemove()
    {
        var accessibleRolls = new List<(int, int)>();
        for (int y = 0; y < Grid.Count; y++)
        {
            for (int x = 0; x < Grid[y].Count; x++)
            {
                if (!IsRoll(y, x))
                {
                    continue;
                }

                var topLeft = IsRoll(y - 1, x - 1);
                var top = IsRoll(y - 1, x);
                var topRight = IsRoll(y - 1, x + 1);
                var left = IsRoll(y, x - 1);
                var right = IsRoll(y, x + 1);
                var bottomLeft = IsRoll(y + 1, x - 1);
                var bottom = IsRoll(y + 1, x);
                var bottomRight = IsRoll(y + 1, x + 1);

                var count = 0;
                if (topLeft)
                    count += 1;
                if (top)
                    count += 1;
                if (topRight)
                    count += 1;
                if (left)
                    count += 1;
                if (right)
                    count += 1;
                if (bottomLeft)
                    count += 1;
                if (bottom)
                    count += 1;
                if (bottomRight)
                    count += 1;

                if (count < 4)
                {
                    accessibleRolls.Add((y, x));
                }
            }
        }

        return accessibleRolls;
    }

    public int GetRollCountPart2()
    {
        int lastCount;
        var total = 0;
        do
        {
            var rolls = GetRollsToRemove();
            lastCount = rolls.Count;
            total += lastCount;

            RemoveRolls(rolls);
        } while (lastCount > 0);

        return total;
    }

    private void RemoveRolls(List<(int Y, int X)> rolls)
    {
        foreach (var (y, x) in rolls)
        {
            Grid[y][x] = '.';
        }
    }

    private char Get(int y, int x)
    {
        if (y < 0)
        {
            return '.';
        }

        if (y >= Grid.Count)
        {
            return '.';
        }

        if (x < 0)
        {
            return '.';
        }

        if (x >= Grid[0].Count)
        {
            return '.';
        }

        return Grid[y][x];
    }

    private bool IsRoll(int y, int x)
    {
        var c = Get(y, x);
        return c == '@';
    }
}

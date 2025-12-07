namespace AdventOfCode2025.Problem7;

public class Problem7
{
    public static int Solve(string content)
    {
        var grid = new Grid(content);

        grid.Run();

        return grid.SplitCount;
    }

    public static long Solve2(string content)
    {
        var grid = new Grid(content);

        grid.Run();

        return grid.TimelineCount;
    }

    [Fact]
    public void Example()
    {
        var result = Solve(Content.EXAMPLE);

        Assert.Equal(21, result);
    }

    [Fact]
    public void Example2()
    {
        var result = Solve2(Content.EXAMPLE);

        Assert.Equal(40, result);
    }

    [Fact]
    public void File()
    {
        var result = Solve(Content.FILE);

        Assert.Equal(1662, result);
    }

    [Fact]
    public void File2()
    {
        var result = Solve2(Content.FILE);

        Assert.Equal(40941112789504, result);
    }
}

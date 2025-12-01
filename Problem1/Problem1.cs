namespace AdventOfCode2025.Problem1;

public partial class Problem1
{
    [Fact]
    public void Example1()
    {
        var safe = new Safe();
        foreach (var line in Content.EXAMPLE_DATA.EnumerateLines())
        {
            safe.Move(line.ToString());
        }

        Assert.Equal(3, safe.ZeroCount);
        Assert.Equal(6, safe.Dial.ZeroCount);
    }

    [Fact]
    public void Solve()
    {
        var safe = new Safe();

        foreach (var line in Content.FILE_DATA.EnumerateLines())
        {
            safe.Move(line.ToString());
        }

        Assert.Equal(1021, safe.ZeroCount);
        Assert.Equal(5933, safe.Dial.ZeroCount);
    }
}

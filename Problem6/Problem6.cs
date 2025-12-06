namespace AdventOfCode2025.Problem6;

public class Problem6
{
    private static long Solve(string content)
    {
        var maths = MathProblem.ParseContent(content);

        return maths.Sum(m => m.Run());
    }

    private static long Solve2(string content)
    {
        var maths = MathProblem.ParseContent2(content);

        return maths.Sum(m => m.Run());
    }

    [Fact]
    public void Example()
    {
        var result = Solve(Content.EXAMPLE);

        Assert.Equal(4277556, result);
    }

    [Fact]
    public void Example2()
    {
        var result = Solve2(Content.EXAMPLE);

        Assert.Equal(3263827, result);
    }

    [Fact]
    public void File()
    {
        var result = Solve(Content.FILE);

        Assert.Equal(4387670995909, result);
    }

    [Fact]
    public void File2()
    {
        var result = Solve2(Content.FILE);

        Assert.Equal(9625320374409, result);
    }
}

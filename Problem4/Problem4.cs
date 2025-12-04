namespace AdventOfCode2025.Problem4;

public class Problem4
{
    private static int Solve(string content)
    {
        var department = new PrintingDepartment(content);

        return department.GetRollsToRemove().Count;
    }

    private static int Solve2(string content)
    {
        var department = new PrintingDepartment(content);

        return department.GetRollCountPart2();
    }

    [Fact]
    public void Example()
    {
        var result = Solve(Content.EXAMPLE);
        var result2 = Solve2(Content.EXAMPLE);

        Assert.Equal(13, result);
        Assert.Equal(43, result2);
    }

    [Fact]
    public void File()
    {
        var result = Solve(Content.FILE);
        var result2 = Solve2(Content.FILE);

        Assert.Equal(1349, result);
        Assert.Equal(8277, result2);
    }
}

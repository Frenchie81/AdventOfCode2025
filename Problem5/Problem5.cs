namespace AdventOfCode2025.Problem5;

public class Problem5
{
    private static long Solve(string content)
    {
        var inventory = Inventory.Parse(content);
        return inventory.CountFreshIngredients();
    }

    [Fact]
    public void Example()
    {
        var result = Solve(Content.EXAMPLE);

        Assert.Equal(3, result);
    }

    [Fact]
    public void File()
    {
        var result = Solve(Content.FILE);

        Assert.Equal(577, result);
    }
}

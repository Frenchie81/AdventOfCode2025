namespace AdventOfCode2025.Problem5;

public class Problem5
{
    private static (long FreshProducts, long FreshIngredients) Solve(string content)
    {
        var inventory = Inventory.Parse(content);
        var freshProducts = inventory.CountFreshProducts();
        var freshIngredients = inventory.CountFreshIngredients();
        return (freshProducts, freshIngredients);
    }

    [Fact]
    public void Example()
    {
        var (freshProducts, freshIngredients) = Solve(Content.EXAMPLE);

        Assert.Equal(3, freshProducts);
        Assert.Equal(14, freshIngredients);
    }

    [Fact]
    public void File()
    {
        var (freshProducts, freshIngredients) = Solve(Content.FILE);

        Assert.Equal(577, freshProducts);
        Assert.Equal(350513176552950, freshIngredients);
    }
}

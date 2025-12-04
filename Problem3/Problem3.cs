namespace AdventOfCode2025.Problem3;

public class Problem3
{
    private static List<BatteryBank> ParseContent(string content)
    {
        var batteries = new List<BatteryBank>();

        foreach (var line in content.EnumerateLines())
        {
            var intArray = new int[line.Length];
            for (int i = 0; i < line.Length; i++)
            {
                intArray[i] = int.Parse(line[i].ToString());
            }
            batteries.Add(new BatteryBank(intArray));
        }

        return batteries;
    }

    [Fact]
    public void Example()
    {
        var batteries = ParseContent(Content.EXAMPLE);

        var sum = batteries.Select(b => b.GetJoltage2(2)).Sum();
        var sum2 = batteries.Select(b => b.GetJoltage2(12)).Sum();

        Assert.Equal(357, sum);
        Assert.Equal(3121910778619, sum2);
    }

    [Fact]
    public void File()
    {
        var batteries = ParseContent(Content.FILE);

        var sum = batteries.Select(b => b.GetJoltage2(2)).Sum();
        var sum2 = batteries.Select(b => b.GetJoltage2(12)).Sum();

        Assert.Equal(17085, sum);
        Assert.Equal(169408143086082, sum2);
    }
}

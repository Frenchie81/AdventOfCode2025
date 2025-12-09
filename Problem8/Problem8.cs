namespace AdventOfCode2025.Problem8;

public record Distance(JunctionBox A, JunctionBox B, double D);

public class Problem8
{
    private static List<Distance> GetDistances(List<JunctionBox> junctionBoxes)
    {
        var distances = new List<Distance>();
        for (var i = 0; i < junctionBoxes.Count; i++)
        {
            var a = junctionBoxes[i];
            for (var j = i + 1; j < junctionBoxes.Count; j++)
            {
                var b = junctionBoxes[j];
                var distance = a.DistanceFrom(b);
                distances.Add(new Distance(a, b, distance));
            }
        }

        return distances;
    }

    private static (int Result1, long Result2) ApplyCircuits(
        List<JunctionBox> junctionBoxes,
        int numberOfIterations
    )
    {
        var distances = GetDistances(junctionBoxes).OrderBy(d => d.D).ToArray();
        var circuits = new Dictionary<int, List<JunctionBox>>();

        for (var i = 0; i < junctionBoxes.Count; i++)
        {
            circuits.Add(i, [junctionBoxes[i]]);
        }

        JunctionBox? lastA = null;
        JunctionBox? lastB = null;
        if (junctionBoxes.Count < numberOfIterations)
        {
            numberOfIterations = distances.Length;
        }
        for (var i = 0; i < numberOfIterations; i++)
        {
            var distance = distances[i];
            var circuitA = circuits.First(c => c.Value.Contains(distance.A));
            var circuitB = circuits.First(c => c.Value.Contains(distance.B));

            if (circuitA.Key == circuitB.Key)
            {
                // nothing to do here
                continue;
            }

            foreach (var val in circuitB.Value)
            {
                circuitA.Value.Add(val);
            }

            circuitB.Value.Clear();

            if (circuits.Any(c => c.Value.Count == junctionBoxes.Count))
            {
                lastA = distance.A;
                lastB = distance.B;
            }
        }

        var threeLargest = circuits
            .OrderByDescending(c => c.Value.Count)
            .Take(3)
            .Aggregate(1, (a, b) => a * b.Value.Count);

        if (lastA is not null && lastB is not null)
        {
            return (threeLargest, lastA.X * lastB.X);
        }

        return (threeLargest, 0);
    }

    private static (int Result1, long Result2) Solve(string content, int iterations)
    {
        var junctionBoxes = JunctionBox.ParseContent(content);
        return ApplyCircuits(junctionBoxes, iterations);
    }

    [Fact]
    public void Example()
    {
        var (result, _) = Solve(Content.EXAMPLE, 10);
        var (_, result2) = Solve(Content.EXAMPLE, int.MaxValue);

        Assert.Equal(40, result);
        Assert.Equal(25272, result2);
    }

    [Fact]
    public void File()
    {
        var (result, _) = Solve(Content.FILE, 1000);
        var (_, result2) = Solve(Content.FILE, int.MaxValue);

        Assert.Equal(164475, result);
        Assert.Equal(169521198, result2);
    }
}

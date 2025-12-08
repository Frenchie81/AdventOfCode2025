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

    private static int ApplyCircuits2(List<JunctionBox> junctionBoxes, int numberOfIterations)
    {
        var distances = GetDistances(junctionBoxes).OrderBy(d => d.D).ToArray();
        var circuits = new Dictionary<int, List<JunctionBox>>();

        for (var i = 0; i < junctionBoxes.Count; i++)
        {
            circuits.Add(i, [junctionBoxes[i]]);
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
        }

        var threeLargest = circuits
            .OrderByDescending(c => c.Value.Count)
            .Take(3)
            .Aggregate(1, (a, b) => a * b.Value.Count);

        return threeLargest;
    }

    private static long Solve(string content, int iterations)
    {
        var junctionBoxes = JunctionBox.ParseContent(content);
        return ApplyCircuits2(junctionBoxes, iterations);
    }

    [Fact]
    public void Example()
    {
        var result = Solve(Content.EXAMPLE, 10);

        Assert.Equal(40, result);
    }

    [Fact]
    public void File()
    {
        var result = Solve(Content.FILE, 1000);

        Assert.Equal(164475, result);
    }
}

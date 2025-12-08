namespace AdventOfCode2025.Problem8;

public class JunctionBox(long x, long y, long z, int? circuitId = null)
{
    public long X => x;

    public long Y => y;

    public long Z => z;

    public int? CircuitId { get; set; } = circuitId;

    public static List<JunctionBox> ParseContent(string content)
    {
        var junctionBoxes = new List<JunctionBox>();

        foreach (var line in content.EnumerateLines())
        {
            var splits = line.ToString().Split(',');
            junctionBoxes.Add(
                new JunctionBox(long.Parse(splits[0]), long.Parse(splits[1]), long.Parse(splits[2]))
            );
        }

        return junctionBoxes;
    }

    public double DistanceFrom(JunctionBox box)
    {
        var diffX = X - box.X;
        var diffY = Y - box.Y;
        var diffZ = Z - box.Z;

        return Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);
    }
}

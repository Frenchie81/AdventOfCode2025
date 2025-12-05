namespace AdventOfCode2025.Problem5;

public class Range(long start, long end)
{
    public long Start { get; private set; } = start;

    public long End { get; private set; } = end;

    public bool IsInRange(long value)
    {
        return (value >= Start) && (value <= End);
    }
}

namespace AdventOfCode2025.Problem5;

public class Range(long start, long end)
{
    public long Start { get; set; } = start;

    public long End { get; set; } = end;

    public bool IsInRange(long value)
    {
        return (value >= Start) && (value <= End);
    }

    public long RangeTotal()
    {
        return End - Start + 1;
    }

    public bool TryCollapse(Range range)
    {
        var startInRange = IsInRange(range.Start);
        var endInRange = IsInRange(range.End);

        if (startInRange && endInRange)
            return true;

        if (startInRange && range.End > End)
        {
            End = range.End;
            return true;
        }

        if (endInRange && range.Start < Start)
        {
            Start = range.Start;
            return true;
        }

        return false;
    }
}

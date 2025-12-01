namespace AdventOfCode2025.Problem1;

public partial class Problem1
{
    public class Dial
    {
        public int Current
        {
            get;
            private set
            {
                if (value == 0)
                {
                    ZeroCount += 1;
                }
                field = value;
            }
        } = 50;

        public int ZeroCount { get; private set; } = 0;

        public void Left()
        {
            if (Current == 0)
            {
                Current = 99;
            }
            else
            {
                Current -= 1;
            }
        }

        public void Right()
        {
            if (Current == 99)
            {
                Current = 0;
            }
            else
            {
                Current += 1;
            }
        }
    }
}

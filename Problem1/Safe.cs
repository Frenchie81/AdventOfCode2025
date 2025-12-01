namespace AdventOfCode2025.Problem1;

public partial class Problem1
{
    public class Safe
    {
        public Dial Dial { get; private set; } = new Dial();

        public int ZeroCount { get; private set; } = 0;

        public void Move(string value)
        {
            var (direction, moves) = Parse(value);

            switch (direction)
            {
                case Direction.Left:
                    for (int i = 0; i < moves; i++)
                    {
                        Dial.Left();
                    }
                    break;
                case Direction.Right:
                    for (int i = 0; i < moves; i++)
                    {
                        Dial.Right();
                    }
                    break;
            }

            if (Dial.Current == 0)
                ZeroCount += 1;
        }

        private static (Direction Direction, int moves) Parse(string value)
        {
            var directionChar = value[0];
            var direction = Direction.Right;
            if (directionChar == 'L')
            {
                direction = Direction.Left;
            }

            var remainder = value[1..];
            return (direction, int.Parse(remainder));
        }
    }
}

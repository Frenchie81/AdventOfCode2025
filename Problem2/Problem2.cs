namespace AdventOfCode2025.Problem2;

public class Problem2
{
    private static (long Problem1, long Problem2) Solve(string content)
    {
        var invalidIds1 = new List<long>();
        var invalidIds2 = new List<long>();
        var numbers = content.Split(',');

        foreach (var number in numbers)
        {
            var splits = number.Split('-');
            var lowerBound = long.Parse(splits[0]);
            var upperBound = long.Parse(splits[1]);
            for (long i = lowerBound; i <= upperBound; i++)
            {
                if (!IsValidProductNumber1(i.ToString()))
                {
                    invalidIds1.Add(i);
                }
                if (!IsValidProductNumber2(i.ToString()))
                {
                    invalidIds2.Add(i);
                }
            }
        }

        return (invalidIds1.Sum(), invalidIds2.Sum());
    }

    private static bool IsValidProductNumber1(string number)
    {
        if (number.Length % 2 != 0)
        {
            // odd numbers can't be repetitive
            return true;
        }

        var half = number.Length / 2;
        var left = number[..half];
        var right = number[half..];

        var isValid = left != right;
        return isValid;
    }

    private static bool IsValidProductNumber2(string number)
    {
        var middle = number.Length / 2;
        for (int window = 1; window <= middle; window++)
        {
            var chunks = number.Chunk(window).Select(c => new string(c)).ToArray();
            if (chunks.Distinct().Count() == 1)
            {
                return false;
            }
        }

        return true;
    }

    [Fact]
    public void IsValidProductNumber1_should_match_repeats()
    {
        var number = "1010";
        var isValidProductNumber = IsValidProductNumber1(number);
        Assert.False(isValidProductNumber);
    }

    [Fact]
    public void IsValidProductNumber2_should_match_repeats()
    {
        var number = "123123123";
        var isValidProductNumber = IsValidProductNumber2(number);
        Assert.False(isValidProductNumber);
    }

    [Fact]
    public void IsValidProductNumber_should_pass_non_repeats()
    {
        var number = "1012";
        var isValidProductNumber = IsValidProductNumber1(number);
        Assert.True(isValidProductNumber);
    }

    [Fact]
    public void IsValidProductNumber2_should_pass_non_repeats()
    {
        var number = "998";
        var isValidProductNumber = IsValidProductNumber2(number);
        Assert.True(isValidProductNumber);
    }

    [Fact]
    public void Example()
    {
        var (result1, result2) = Solve(Content.EXAMPLE);

        Assert.Equal(1227775554, result1);
        Assert.Equal(4174379265, result2);
    }

    [Fact]
    public void Answer()
    {
        var (result1, result2) = Solve(Content.FILE);

        Assert.Equal(35367539282, result1);
        Assert.Equal(45814076230, result2);
    }
}

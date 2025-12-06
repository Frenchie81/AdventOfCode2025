using System.Text;
using System.Text.Json;

namespace AdventOfCode2025.Problem6;

public class MathProblem
{
    public static List<MathProblem> ParseContent(string content)
    {
        var maths = new Dictionary<int, MathProblem>();

        foreach (var line in content.EnumerateLines())
        {
            var splits = line.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < splits.Length; i++)
            {
                if (!maths.TryGetValue(i, out MathProblem? math))
                {
                    math = new MathProblem();
                    maths.Add(i, math);
                }

                var split = splits[i];

                if (long.TryParse(split, out var splitVal))
                {
                    math.Values.Enqueue(splitVal);
                }
                else
                {
                    math.Operation = split == "+" ? Operation.Add : Operation.Multiply;
                }
            }
        }

        return [.. maths.Values];
    }

    public static List<MathProblem> ParseContent2(string content)
    {
        var lines = content.Split("\n");
        var operations = lines.Last();

        var maths = new List<MathProblem>();
        MathProblem? currentMath = null;
        for (int i = 0; i < operations.Length; i++)
        {
            var c = operations[i];
            if (!char.IsWhiteSpace(c))
            {
                currentMath = new MathProblem()
                {
                    Operation = c == '+' ? Operation.Add : Operation.Multiply,
                };
                maths.Add(currentMath);
            }

            if (currentMath != null)
            {
                var sb = new StringBuilder();
                for (var j = 0; j < lines.Length - 1; j++)
                {
                    sb.Append(lines[j][i]);
                }
                var number = sb.ToString();
                if (long.TryParse(number, out var parsed))
                {
                    currentMath.Values.Enqueue(parsed);
                }
            }
        }

        return maths;
    }

    public Queue<long> Values { get; } = [];

    public Operation Operation { get; private set; }

    public long Run()
    {
        if (Values.Count == 0)
        {
            return 0;
        }

        long answer = Values.Dequeue();
        while (Values.Count > 0)
        {
            var value = Values.Dequeue();
            switch (Operation)
            {
                case Operation.Add:
                    answer += value;
                    break;
                case Operation.Multiply:
                    answer *= value;
                    break;
            }
        }

        return answer;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}

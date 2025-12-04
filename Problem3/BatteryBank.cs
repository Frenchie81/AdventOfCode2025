using System.Text;

namespace AdventOfCode2025.Problem3;

public class BatteryBank(int[] batteries)
{
    public int[] Batteries { get; } = batteries;

    public long GetJoltage()
    {
        var maxLeftPos = 0;

        for (int i = 1; i < Batteries.Length - 1; i++)
        {
            if (Batteries[maxLeftPos] == 9)
                break;

            if (Batteries[i] > Batteries[maxLeftPos])
            {
                maxLeftPos = i;
            }
        }

        var maxRightPos = maxLeftPos + 1;
        for (int i = maxRightPos; i < Batteries.Length; i++)
        {
            if (Batteries[i] > Batteries[maxRightPos])
            {
                maxRightPos = i;
            }
        }

        var joltage = long.Parse($"{Batteries[maxLeftPos]}{Batteries[maxRightPos]}");
        return joltage;
    }

    public long GetJoltage2(int totalSlots)
    {
        var slots = new int[totalSlots];

        var startIndex = 0;
        for (int i = 0; i < slots.Length; i++)
        {
            var foundIndex = FindNextValue(startIndex, Batteries.Length - slots.Length + i);
            slots[i] = foundIndex;
            startIndex = foundIndex + 1;
        }

        var sb = new StringBuilder();
        foreach (var s in slots)
        {
            sb.Append(Batteries[s]);
        }

        return long.Parse(sb.ToString());
    }

    public int FindNextValue(int start, int end)
    {
        var highIndex = start;
        for (int i = start + 1; i <= end; i++)
        {
            if (Batteries[i] > Batteries[highIndex])
            {
                highIndex = i;
            }
        }
        return highIndex;
    }
}

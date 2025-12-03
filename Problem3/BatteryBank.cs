using System.Text.Json;

namespace AdventOfCode2025.Problem3;

public class BatteryBank(int[] batteries)
{
    public long GetJoltage()
    {
        var maxLeftPos = 0;

        for (int i = 1; i < batteries.Length - 1; i++)
        {
            if (batteries[maxLeftPos] == 9)
                break;

            if (batteries[i] > batteries[maxLeftPos])
            {
                maxLeftPos = i;
            }
        }

        var maxRightPos = maxLeftPos + 1;
        for (int i = maxRightPos; i < batteries.Length; i++)
        {
            if (batteries[i] > batteries[maxRightPos])
            {
                maxRightPos = i;
            }
        }

        var joltage = long.Parse($"{batteries[maxLeftPos]}{batteries[maxRightPos]}");
        return joltage;
    }
}

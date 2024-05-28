using System;
using System.Collections.Generic;

public class SmallestDistance
{
    private List<int> numbers;

    public SmallestDistance()
    {
        numbers = new List<int>();
    }

    public void Add(int x)
    {
        numbers.Add(x);
    }

    public int Calculate()
    {
        if (numbers.Count < 2)
        {
            throw new InvalidOperationException("At least two numbers are required to calculate the smallest distance.");
        }

        numbers.Sort();

        int minDistance = int.MaxValue;

        for (int i = 1; i < numbers.Count; i++)
        {
            int distance = numbers[i] - numbers[i - 1];
            if (distance < minDistance)
            {
                minDistance = distance;
            }
        }

        return minDistance;
    }
}

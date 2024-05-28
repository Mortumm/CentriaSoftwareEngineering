namespace Exercise005;
using System;
using System.Collections.Generic;

public class Split
{
    public int Calculate(int[] t)
    {
        int n = t.Length;
        int[] prefixSums = new int[n];
        int totalSum = 0;

        for (int i = 0; i < n; i++)
        {
            totalSum += t[i];
            prefixSums[i] = totalSum;
        }

        int splitCount = 0;

        for (int i = 0; i < n - 1; i++)
        {
            int leftSum = prefixSums[i];
            int rightSum = totalSum - leftSum;

            if (leftSum == rightSum)
            {
                splitCount++;
            }
        }

        return splitCount;
    }
}

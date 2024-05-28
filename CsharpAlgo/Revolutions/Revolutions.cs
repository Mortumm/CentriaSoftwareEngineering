namespace Exercise004;
using System;

public class Revolutions
{
    public int Calculate(int[] t)
    {
        int n = t.Length;
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            if (t[i] != -1)
            {
                int current = i;
                int next = -1;

                while (t[current] != -1)
                {
                    next = t[current] - 1;
                    t[current] = -1;
                    current = next;
                }

                count++;
            }
        }

        return count;
    }
}

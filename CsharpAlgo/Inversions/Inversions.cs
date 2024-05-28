using System;

namespace Exercise005
{
    public class Inversions
    {
        public int[] Create(int n, int k)
        {
            if (k < 0 || k > n * (n - 1) / 2)
            {
                throw new ArgumentException("Invalid inversion count.");
            }

            int[] arr = new int[n];

            // Initialize the array with numbers from 1 to n
            for (int i = 0; i < n; i++)
            {
                arr[i] = i + 1;
            }

            // Create the desired number of inversions by swapping elements
            int swaps = k;

            for (int i = 0; i < n - 1 && swaps > 0; i++)
            {
                int maxSwaps = Math.Min(swaps, n - 1 - i);

                // Swap 'maxSwaps' adjacent elements starting from index 'i'
                for (int j = 0; j < maxSwaps; j++)
                {
                    int temp = arr[i + j];
                    arr[i + j] = arr[i + j + 1];
                    arr[i + j + 1] = temp;
                }

                swaps -= maxSwaps;
            }

            return arr;
        }
    }
}

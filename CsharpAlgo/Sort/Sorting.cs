namespace Exercise003
{
    public class Sorting
    {
        // Merge Sort
        public int[] MergeSort(int[] t)
        {
            if (t.Length <= 1)
            {
                return t;
            }

            int middle = t.Length / 2;
            int[] left = new int[middle];
            int[] right = new int[t.Length - middle];

            for (int i = 0; i < middle; i++)
            {
                left[i] = t[i];
            }

            for (int i = middle; i < t.Length; i++)
            {
                right[i - middle] = t[i];
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] < right[j])
                {
                    result[k++] = left[i++];
                }
                else
                {
                    result[k++] = right[j++];
                }
            }

            while (i < left.Length)
            {
                result[k++] = left[i++];
            }

            while (j < right.Length)
            {
                result[k++] = right[j++];
            }

            return result;
        }

        // Quick Sort
        // Quick Sort
        public int[] QuickSort(int[] t, int a, int b)
        {
            if (a < b)
            {
                int pivotIndex = Pivot(t, a, b); // Corrected to call the Pivot method
                QuickSort(t, a, pivotIndex - 1);
                QuickSort(t, pivotIndex + 1, b);
            }

            return t;
        }

        private int Pivot(int[] t, int a, int b)
        {
            int pivot = t[b];
            int i = a - 1;

            for (int j = a; j < b; j++)
            {
                if (t[j] < pivot)
                {
                    i++;
                    int temp = t[i];
                    t[i] = t[j];
                    t[j] = temp;
                }
            }

            int temp2 = t[i + 1];
            t[i + 1] = t[b];
            t[b] = temp2;

            return i + 1;
        }


        private int Partition(int[] t, int low, int high)
        {
            int pivot = t[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (t[j] < pivot)
                {
                    i++;
                    int temp = t[i];
                    t[i] = t[j];
                    t[j] = temp;
                }
            }

            int temp2 = t[i + 1];
            t[i + 1] = t[high];
            t[high] = temp2;

            return i + 1;
        }
    }
}

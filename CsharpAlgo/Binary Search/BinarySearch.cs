namespace Exercise004
{
    public class BinarySearch
    {
        public bool Find(int[] t, int x)
        {
            // Step 1: Sort the array
            Array.Sort(t);

            int left = 0;
            int right = t.Length - 1;

            // Step 3: Binary search
            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (t[mid] == x)
                {
                    return true; // Step 3: Element found
                }
                else if (t[mid] < x)
                {
                    left = mid + 1; // Step 3: Search the right half
                }
                else
                {
                    right = mid - 1; // Step 3: Search the left half
                }
            }

            // Step 4: Element not found
            return false;
        }
    }
}

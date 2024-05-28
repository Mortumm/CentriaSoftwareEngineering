public class Changes
{
    public int Calculate(int[] t)
    {
        int changes = 0; // Initialize the number of changes needed.

        for (int i = 1; i < t.Length; i++)
        {
            if (t[i] == t[i - 1])
            {
                // Find the next available number that is not equal to the previous or next element.
                int nextNumber = t[i - 1] + 1;
                while ((i + 1 < t.Length && t[i + 1] == nextNumber) || t[i - 1] == nextNumber)
                {
                    nextNumber++;
                }

                t[i] = nextNumber;
                changes++;
            }
        }

        return changes;
    }
}

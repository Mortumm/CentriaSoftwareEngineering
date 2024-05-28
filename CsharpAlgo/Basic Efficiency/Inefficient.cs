namespace Exercise001
{
    public class Inefficient
    {
        public int Counter(string chars)
        {
            int counter = 0;
            int n = chars.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (chars[i] == '0' && chars[j] == '1')
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }
    }
}

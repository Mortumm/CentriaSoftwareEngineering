namespace Exercise001
{
    public class Efficient
    {
        public int Counter(string chars)
        {
            int counter = 0;
            int zeros = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '0')
                {
                    zeros++;
                }
                else
                {
                    counter += zeros;
                }
            }

            return counter;
        }
    }
}

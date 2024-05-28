
namespace Exercise001
{
    // DO NOT TOUCH THE CODE BELOW
    using System;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Inefficient inefficient = new Inefficient();
            Efficient efficient = new Efficient();
            // Same input for both, so output should be same
            string input = CreateInput(15000);

            // Timing for inefficient
            DateTime startInefficient = DateTime.Now;
            Console.WriteLine("Inefficient pairs found: " + inefficient.Counter(input));
            DateTime endInefficient = DateTime.Now;
            Console.WriteLine("Time the inefficient took: " + endInefficient.Subtract(startInefficient).Ticks);

            // Timing for efficient
            DateTime startEfficient = DateTime.Now;
            Console.WriteLine("Efficient pairs found: " + efficient.Counter(input));
            DateTime endEfficient = DateTime.Now;
            Console.WriteLine("Time the efficient took: " + endEfficient.Subtract(startEfficient).Ticks);
        }

        public static string CreateInput(int n)
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                sb.Append(random.Next(0, 2).ToString());
            }
            return sb.ToString();
        }
    }
}
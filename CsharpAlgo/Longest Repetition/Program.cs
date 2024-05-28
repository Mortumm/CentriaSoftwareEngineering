namespace Exercise002
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            LongestRepetition p = new LongestRepetition();
            Console.WriteLine(p.Calculate(new int[] { 1, 2, 1, 1, 2 })); // 2
            Console.WriteLine(p.Calculate(new int[] { 1, 2, 3, 4, 5 })); // 1
            Console.WriteLine(p.Calculate(new int[] { 12 })); // 1
            Console.WriteLine(p.Calculate(new int[] { 1, 1, 1, 1, 1 })); // 5
        }
    }
}

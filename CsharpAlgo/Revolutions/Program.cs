namespace Exercise004
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            Revolutions r = new Revolutions();
            Console.WriteLine(r.Calculate(new int[] { 4, 1, 3, 2, 5 })); // 3
            Console.WriteLine(r.Calculate(new int[] { 1, 2, 3, 4, 5 })); // 1
            Console.WriteLine(r.Calculate(new int[] { 5, 4, 3, 2, 1 })); // 5
            Console.WriteLine(r.Calculate(new int[] { 4, 3, 2, 1 })); // 4       
        }
    }
}

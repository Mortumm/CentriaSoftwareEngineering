namespace Exercise004
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            BinarySearch b = new BinarySearch();
            Console.WriteLine(b.Find(new int[] { 4, 1, 8, 5 }, 2)); // false
            Console.WriteLine(b.Find(new int[] { 0, 0 }, 0)); // true
            Console.WriteLine(b.Find(new int[] { 4, 1, 8, 5, 8, 7, 4, 2, 3 }, 2)); // true
            Console.WriteLine(b.Find(new int[] { 0 }, 0)); // true
        }
    }
}

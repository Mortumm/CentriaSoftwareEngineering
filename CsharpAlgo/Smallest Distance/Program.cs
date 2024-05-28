namespace Exercise003
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            SmallestDistance s = new SmallestDistance();
            s.Add(3);
            s.Add(88);
            Console.WriteLine(s.Calculate()); // 5
            s.Add(20);
            Console.WriteLine(s.Calculate()); // 5
            s.Add(9);
            Console.WriteLine(s.Calculate()); // 1
            s.Add(20);
            Console.WriteLine(s.Calculate()); // 0
        }
    }
}
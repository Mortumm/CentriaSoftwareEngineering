namespace Exercise001
{
    using System;
    public class Numbers
    {
        public int Sum(int x)
        {
            int sum = 0;
            while (x != 0)
            {
                sum += x % 10;
                x /= 10;
            }
            return sum;
        }
        public static void Main(string[] args)
        {
            Numbers num = new Numbers();
            Console.WriteLine(num.Sum(4075)); // 16
            Console.WriteLine(num.Sum(3)); // 3
            Console.WriteLine(num.Sum(999999999)); // 81
        }
    }
}
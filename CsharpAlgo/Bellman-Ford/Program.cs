namespace Exercise001
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            BellmanFord bf1 = new BellmanFord(5);
            bf1.AddRoad(1, 2, 7);
            bf1.AddRoad(2, 4, 2);
            bf1.AddRoad(1, 3, 6);
            bf1.AddRoad(3, 4, 5);
            bf1.AddRoad(4, 5, 3);
            Console.WriteLine(bf1.Calculate(1, 5)); // 12


            BellmanFord bf2 = new BellmanFord(7);
            bf2.AddRoad(1, 2, 7);
            bf2.AddRoad(2, 4, 2);
            bf2.AddRoad(1, 3, 6);
            bf2.AddRoad(3, 4, 5);
            bf2.AddRoad(4, 5, 3);
            bf2.AddRoad(6, 7, 3);
            Console.WriteLine(bf2.Calculate(1, 7)); // -1
        }
    }
}
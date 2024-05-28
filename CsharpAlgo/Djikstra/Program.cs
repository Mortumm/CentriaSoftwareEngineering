namespace Exercise002
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            Dijkstra d = new Dijkstra(6);
            d.AddRoad(1, 2, 7);
            d.AddRoad(2, 4, 2);
            d.AddRoad(1, 3, 6);
            d.AddRoad(3, 4, 5);
            d.AddRoad(4, 5, 3);
            Console.WriteLine(d.Calculate(1, 5)); // 12
        }
    }
}

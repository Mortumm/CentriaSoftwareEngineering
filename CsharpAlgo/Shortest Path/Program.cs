namespace Exercise004
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            ShortestPath s = new ShortestPath(5);
            s.AddRoad(1, 2, 7);
            s.AddRoad(2, 4, 2);
            s.AddRoad(1, 3, 6);
            s.AddRoad(3, 4, 5);
            s.AddRoad(4, 5, 3);
            s.Create(1, 5).ForEach(Console.Write); // 1245 
            Console.WriteLine();
            s.Create(1, 2).ForEach(Console.Write); // 12 
            Console.WriteLine();
            s.Create(1, 4).ForEach(Console.Write); // 124 
            Console.WriteLine();
            s.Create(4, 1).ForEach(Console.Write); // 421 
            Console.WriteLine();
        }
    }
}

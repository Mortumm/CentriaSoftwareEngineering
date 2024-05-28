namespace Exercise003
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            FloydWarshall fw = new FloydWarshall(5);
            fw.AddRoad(1, 2, 7);
            fw.AddRoad(2, 4, 2);
            fw.AddRoad(1, 3, 6);
            fw.AddRoad(3, 4, 5);
            fw.AddRoad(4, 5, 3);
            Console.WriteLine(fw.Calculate(1, 5)); // 12
        }
    }
}
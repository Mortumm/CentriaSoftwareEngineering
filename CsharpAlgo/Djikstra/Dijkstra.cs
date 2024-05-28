using System;
using System.Collections.Generic;

namespace Exercise002
{
    public class Dijkstra
    {
        private int n;

        private Dictionary<int, List<Edge>> graph;

        public Dijkstra(int n)
        {
            this.n = n;
            this.graph = new Dictionary<int, List<Edge>>();

            for (int i = 1; i <= n; i++)
            {
                graph[i] = new List<Edge>();
            }
        }

        public void AddRoad(int a, int b, int d)
        {
            graph[a].Add(new Edge(b, d));
            graph[b].Add(new Edge(a, d));
        }

        public int Calculate(int x, int y)
        {
            Dictionary<int, int> distance = new Dictionary<int, int>();
            for (int i = 1; i <= n; i++)
            {
                distance[i] = int.MaxValue;
            }

            distance[x] = 0;
            HashSet<int> visited = new HashSet<int>();

            while (visited.Count < n)
            {
                int minNode = -1;
                int minDist = int.MaxValue;

                foreach (var kvp in distance)
                {
                    if (!visited.Contains(kvp.Key) && kvp.Value < minDist)
                    {
                        minNode = kvp.Key;
                        minDist = kvp.Value;
                    }
                }

                if (minNode == -1)
                {
                    break;
                }

                visited.Add(minNode);

                foreach (var edge in graph[minNode])
                {
                    int neighbor = edge.destination;
                    int alt = distance[minNode] + edge.weight;
                    if (alt < distance[neighbor])
                    {
                        distance[neighbor] = alt;
                    }
                }
            }

            return distance[y] == int.MaxValue ? -1 : distance[y];
        }
    }
}

using System;
using System.Collections.Generic;

namespace Exercise001
{
  public class BellmanFord
  {
    private int n;
    private List<Edge> edges = new List<Edge>();

    public BellmanFord(int n)
    {
      this.n = n;
    }

    public void AddRoad(int a, int b, int d)
    {
      // Add edge to the list
      edges.Add(new Edge(a, b, d));
    }

    public int Calculate(int x, int y)
    {
      // distances with maximum values
      int[] distance = new int[n + 1];
      for (int i = 1; i <= n; i++)
      {
        distance[i] = int.MaxValue;
      }

      // distance to the source to 0
      distance[x] = 0;

      // find the shortest distance
      for (int i = 1; i <= n - 1; i++)
      {
        foreach (Edge edge in edges)
        {
          if (distance[edge.source] != int.MaxValue && distance[edge.source] + edge.weight < distance[edge.end])
          {
            distance[edge.end] = distance[edge.source] + edge.weight;
          }
        }
      }

      // negative cycles
      foreach (Edge edge in edges)
      {
        if (distance[edge.source] != int.MaxValue && distance[edge.source] + edge.weight < distance[edge.end])
        {
          // if negative, return -1
          return -1;
        }
      }

      return distance[y] == int.MaxValue ? -1 : distance[y];
    }
  }
}

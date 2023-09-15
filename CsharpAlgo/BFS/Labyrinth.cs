using System;
using System.Collections.Generic;

public class Labyrinth
{
    public string Search(char[,] labyrinth)
    {
        int n = labyrinth.GetLength(0);
        int m = labyrinth.GetLength(1);

        // 'x' and 'y' in the labyrinth.
        int startX = -1, startY = -1, endX = -1, endY = -1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (labyrinth[i, j] == 'x')
                {
                    startX = i;
                    startY = j;
                }
                else if (labyrinth[i, j] == 'y')
                {
                    endX = i;
                    endY = j;
                }
            }
        }

        // Check if 'x' or 'y' are present
        if (startX == -1 || startY == -1 || endX == -1 || endY == -1)
        {
            return "Error: Missing 'x' or 'y' in the labyrinth.";
        }

        // a queue for BFS
        Queue<(int, int)> queue = new Queue<(int, int)>();
        bool[,] visited = new bool[n, m];
        queue.Enqueue((startX, startY));
        visited[startX, startY] = true;

        // right, left, down, up.
        int[] dx = { 0, 0, 1, -1 };
        int[] dy = { 1, -1, 0, 0 };
        string[] directions = { "R", "L", "D", "U" };

        // store directions for each.
        string[,] path = new string[n, m];

        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];

                // check position is in bounds and not visited.
                if (newX >= 0 && newX < n && newY >= 0 && newY < m && labyrinth[newX, newY] != '#' && !visited[newX, newY])
                {
                    queue.Enqueue((newX, newY));
                    visited[newX, newY] = true;
                    path[newX, newY] = directions[i];
                }
            }
        }

        // if there's a path from 'x' to 'y.'
        if (!visited[endX, endY])
        {
            return ""; // no valid path.
        }

        // rebuild the path from 'y' to 'x.'
        string result = "";
        int currX = endX, currY = endY;
        while (currX != startX || currY != startY)
        {
            string direction = path[currX, currY];
            result = direction + result;

            // backtrack.
            switch (direction)
            {
                case "R":
                    currY--;
                    break;
                case "L":
                    currY++;
                    break;
                case "D":
                    currX--;
                    break;
                case "U":
                    currX++;
                    break;
            }
        }

        return result;
    }
}

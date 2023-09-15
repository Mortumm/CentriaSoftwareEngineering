namespace Exercise004
{
  using System;
  public class Program
  {
    public static void Main(string[] args)
    {
      Labyrinth l = new Labyrinth();
      char[,] c =
      { {'#','#','#','#','#','#','#'},
              {'#','x','#','.','.','.','#'},
              {'#','.','#','.','#','.','#'},
              {'#','.','.','.','.','y','#'},
              {'#','#','#','#','#','#','#'} };
      Console.WriteLine(l.Search(c)); // DDRRRRR       

      Labyrinth l2 = new Labyrinth();
      char[,] c2 =
      { {'#','#','#','#','#','#'},
              {'#','x','#','.','y','#'},
              {'#','#','#','#','#','#'} };
      Console.WriteLine(l2.Search(c2)); // empty string 
    }
  }
}

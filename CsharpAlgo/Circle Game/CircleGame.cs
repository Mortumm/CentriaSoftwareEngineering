public class CircleGame
{
  public int Last(int n)
  {
    if (n < 1)
    {
      throw new ArgumentException("Invalid input. n should be greater than or equal to 1.");
    }

    int lastChild = 0;

    for (int i = 2; i <= n; i++)
    {
      lastChild = (lastChild + 2) % i;
    }

    return lastChild + 1;
  }
}

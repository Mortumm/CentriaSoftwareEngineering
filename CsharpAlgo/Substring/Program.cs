namespace Exercise002
{
    using System;

    public class Substrings
    {
        public int Calculate(string text, string sub)
        {
            int count = 0;
            int indexOfSub = text.IndexOf(sub);

            while (indexOfSub != -1)
            {
                count++;
                indexOfSub = text.IndexOf(sub, indexOfSub + 1);
            }

            return count;
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            Substrings subs = new Substrings();
            Console.WriteLine(subs.Calculate("aybabtu", "bab")); // 1
            Console.WriteLine(subs.Calculate("aaaaa", "aa")); // 4
            Console.WriteLine(subs.Calculate("monkey", "banana")); // 0
        }
    }

}

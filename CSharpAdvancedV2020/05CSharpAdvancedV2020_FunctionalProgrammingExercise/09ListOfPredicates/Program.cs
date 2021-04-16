using System;
using System.Linq;

namespace _09ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endNumber = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Predicate<int> isDivided = x =>
            {
                foreach (int divider in dividers)
                {
                    if (x % divider != 0)
                    {
                        return false;
                    }
                }

                return true;
            };

            for (int i = 1; i <= endNumber; i++)
            {
                if (isDivided(i))
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
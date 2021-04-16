using System;
using System.Collections.Generic;
using System.Linq;

namespace _02SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] setsLengths = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstSetLength = setsLengths[0];
            int secondSetLength = setsLengths[1];
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < firstSetLength; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }

            for (int i = 0; i < secondSetLength; i++)
            {
                int number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }

            foreach (int number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
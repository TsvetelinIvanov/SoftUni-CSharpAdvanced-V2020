using System;
using System.Linq;

namespace _04FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {            
            int[] bounds = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int startNumber = bounds[0];
            int endNumber = bounds[1]; 
            string condition = Console.ReadLine();
            Predicate<int> isCondition = x => x % 2 == 0;
            if (condition == "odd")
            {
                isCondition = x => x % 2 != 0;
            }

            for (int i = startNumber; i <= endNumber; i++)
            {
                if (isCondition(i))
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
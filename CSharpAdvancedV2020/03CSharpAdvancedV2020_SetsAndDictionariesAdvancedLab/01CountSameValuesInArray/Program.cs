using System;
using System.Collections.Generic;
using System.Linq;

namespace _01CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Dictionary<double, int> numbersCounts = new Dictionary<double, int>();
            foreach (double number in numbers)
            {
                if (!numbersCounts.ContainsKey(number))
                {
                    numbersCounts[number] = 1;
                }
                else
                {
                    numbersCounts[number]++;
                }
            }

            foreach (KeyValuePair<double, int> number in numbersCounts)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
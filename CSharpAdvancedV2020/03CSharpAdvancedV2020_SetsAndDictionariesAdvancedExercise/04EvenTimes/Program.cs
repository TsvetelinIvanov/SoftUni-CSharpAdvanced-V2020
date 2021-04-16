using System;
using System.Collections.Generic;

namespace _04EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            int numbersCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbersCount; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, 0);
                }

                numbers[number]++;
            }

            foreach (KeyValuePair<int, int> number in numbers)
            {
                if (number.Value % 2 == 0)
                {
                    Console.WriteLine(number.Key);
                }
            }
        }
    }
}
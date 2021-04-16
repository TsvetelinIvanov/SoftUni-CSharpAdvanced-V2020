using System;
using System.Collections.Generic;
using System.Linq;

namespace _03GenericSwapMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = new List<string>();
            int valuesNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < valuesNumber; i++)
            {
                string element = Console.ReadLine();
                elements.Add(element);
            }

            int[] swapIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Swap(elements, swapIndexes[0], swapIndexes[1]);
            elements.ForEach(e => Console.WriteLine($"{e.GetType()}: {e}"));
        }

        private static void Swap<T>(List<T> elements, int firstIndex, int secondIndex)
        {
            T tempElement = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = tempElement;
        }
    }
}
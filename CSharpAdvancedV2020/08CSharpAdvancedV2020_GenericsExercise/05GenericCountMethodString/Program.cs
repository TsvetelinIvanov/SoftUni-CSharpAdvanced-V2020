using System;
using System.Collections.Generic;

namespace _05GenericCountMethodString
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

            string elementToCompare = Console.ReadLine();            
            int greaterElementsCount = Box<string>.GetGreaterElementsCount(elements, elementToCompare);
            Console.WriteLine(greaterElementsCount);
        }
    }
}
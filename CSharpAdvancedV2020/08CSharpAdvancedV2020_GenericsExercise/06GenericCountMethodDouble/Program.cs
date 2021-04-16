using System;
using System.Collections.Generic;

namespace _06GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> elements = new List<double>();
            int valuesNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < valuesNumber; i++)
            {
                string element = Console.ReadLine();
                elements.Add(double.Parse(element));
            }

            double elementToCompare = double.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();
            int greaterElementsCount = box.GetGreaterElementsCount(elements, elementToCompare);
            Console.WriteLine(greaterElementsCount);
        }
    }
}
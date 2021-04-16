using System;
using System.Collections.Generic;
using System.Linq;

namespace _03PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int compoundsNumber = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();
            for (int i = 0; i < compoundsNumber; i++)
            {
                string[] compound = Console.ReadLine().Split();
                for (int j = 0; j < compound.Length; j++)
                {
                    elements.Add(compound[j]);
                }
            }

            elements = elements.OrderBy(e => e).ToHashSet();
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
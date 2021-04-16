using System;
using System.Collections.Generic;
using System.Linq;

namespace _02KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printer = w => Console.WriteLine("Sir " + w);
            List<string> words = Console.ReadLine().Split().ToList();
            words.ForEach(printer);
        }
    }
}
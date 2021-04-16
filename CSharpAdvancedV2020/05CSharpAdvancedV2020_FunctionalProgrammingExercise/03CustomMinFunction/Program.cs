using System;
using System.Linq;

namespace _03CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> takeMin = arr => arr.Min();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(takeMin(numbers));
        }
    }
}
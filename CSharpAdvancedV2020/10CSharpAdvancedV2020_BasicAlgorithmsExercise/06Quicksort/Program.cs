using System;
using System.Linq;

namespace _06Quicksort//In Judje must be paste together with class Quicksort, but it doesn't work good for Judge - 66/100 because of time limitq too slow for big input!
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Quicksort<int>.Sort(array);
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
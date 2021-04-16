using System;
using System.Linq;

namespace _01RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sum(Console.ReadLine().Split().Select(int.Parse).ToArray()));
        }

        private static int Sum(int[] array, int index = 0)
        {
            if (index == array.Length - 1)
            {
                return array[index];
            }

            return array[index] + Sum(array, index + 1);
        }
    }
}
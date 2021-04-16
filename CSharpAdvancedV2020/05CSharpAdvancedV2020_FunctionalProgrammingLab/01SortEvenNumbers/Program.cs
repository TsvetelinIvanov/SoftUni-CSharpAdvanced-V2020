using System;
using System.Linq;

namespace _01SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] evenNumbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ToArray();
            string result = string.Join(", ", evenNumbers);
            Console.WriteLine(result);
        }
    }
}
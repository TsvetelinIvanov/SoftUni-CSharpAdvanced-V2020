using System;
using System.Linq;

namespace _06ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int divider = int.Parse(Console.ReadLine());
            Func<int, bool> isNotDivided = n => n % divider != 0;
            numbers = numbers.Reverse().Where(isNotDivided).ToArray();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
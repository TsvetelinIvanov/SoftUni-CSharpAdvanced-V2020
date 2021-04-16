using System;

namespace _02RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(int.Parse(Console.ReadLine())));
        }

        private static long Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
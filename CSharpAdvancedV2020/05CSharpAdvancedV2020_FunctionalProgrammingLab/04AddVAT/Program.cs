using System;
using System.Linq;

namespace _04AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse)
                .Select(p => p * 1.2).ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, prices.Select(p => p.ToString("f2"))));
        }
    }
}
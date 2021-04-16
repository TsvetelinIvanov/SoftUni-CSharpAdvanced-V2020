using System;
using System.Linq;

namespace _07PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            Predicate<string> isInLength = name => name.Length <= nameLength;
            string[] filteredNames = names.Where(n => isInLength(n)).ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, filteredNames));
        }
    }
}
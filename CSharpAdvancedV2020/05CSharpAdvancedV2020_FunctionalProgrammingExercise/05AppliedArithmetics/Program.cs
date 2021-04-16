using System;
using System.Linq;

namespace _05AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
                else
                {
                    Func<int, int> applayCommand = ApllayCommand(command);
                    numbers = numbers.Select(applayCommand).ToArray();
                }
            }
        }

        private static Func<int, int> ApllayCommand(string command)
        {            
            switch (command)
            {
                case "add":
                    return x => x + 1;
                case "multiply":
                    return x => x * 2;
                case "subtract":
                    return x => x - 1;
                default:
                    return null;
            }
        }
    }
}
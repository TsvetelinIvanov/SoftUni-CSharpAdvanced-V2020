using System;
using System.Collections.Generic;
using System.Linq;

namespace _03MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int queriesCount = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < queriesCount; i++)
            {
                int[] query = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int command = query[0];
                switch (command)
                {
                    case 1:
                        numbers.Push(query[1]);
                        break;
                    case 2:
                        if (numbers.Count > 0)
                        {
                            numbers.Pop();
                        }
                        
                        break;
                    case 3:
                        if (numbers.Count > 0)
                        {
                            Console.WriteLine(numbers.Max());
                        }
                        
                        break;
                    case 4:
                        if (numbers.Count > 0)
                        {
                            Console.WriteLine(numbers.Min());
                        }
                        
                        break;
                    default:
                        Console.WriteLine("Unknown command!");
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}

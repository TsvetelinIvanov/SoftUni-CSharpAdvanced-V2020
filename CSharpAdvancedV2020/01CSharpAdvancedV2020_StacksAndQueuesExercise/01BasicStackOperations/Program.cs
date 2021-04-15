using System;
using System.Collections.Generic;
using System.Linq;

namespace _01BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputCommands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int countOfNumbersToPush = inputCommands[0];
            int countOfNumbersToPop = inputCommands[1];
            int numberToLookingFor = inputCommands[2];
            Stack<int> numbersStack = new Stack<int>();
            for (int i = 0; i < countOfNumbersToPush; i++)
            {
                int numberToPush = inputNumbers[i];
                numbersStack.Push(numberToPush);
            }

            for (int i = 0; i < countOfNumbersToPop; i++)
            {
                numbersStack.Pop();
            }

            if (numbersStack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (numbersStack.Contains(numberToLookingFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbersStack.Min());
            }
        }
    }
}
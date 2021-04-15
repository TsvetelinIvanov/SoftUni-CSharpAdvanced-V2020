using System;
using System.Collections.Generic;
using System.Linq;

namespace _02BasicQueueOperations
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
            Queue<int> numbersQueue = new Queue<int>();
            for (int i = 0; i < countOfNumbersToPush; i++)
            {
                int numberToPush = inputNumbers[i];
                numbersQueue.Enqueue(numberToPush);
            }

            for (int i = 0; i < countOfNumbersToPop; i++)
            {
                numbersQueue.Dequeue();
            }

            if (numbersQueue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (numbersQueue.Contains(numberToLookingFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbersQueue.Min());
            }
        }
    }
}
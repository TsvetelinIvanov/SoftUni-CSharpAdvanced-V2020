using System;
using System.Collections.Generic;
using System.Linq;

namespace _05PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> numbersQueue = new Queue<int>(inputNumbers);
            Queue<int> evenNumbersQueue = new Queue<int>();

            while (numbersQueue.Count > 0)
            {
                if (numbersQueue.Peek() % 2 == 0)
                {
                    int evenNumber = numbersQueue.Dequeue();
                    evenNumbersQueue.Enqueue(evenNumber);
                }
                else
                {
                    numbersQueue.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", evenNumbersQueue));
        }
    }
}
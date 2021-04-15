using System;
using System.Collections.Generic;

namespace _07HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split();
            int number = int.Parse(Console.ReadLine());
            Queue<string> childrenQueue = new Queue<string>(children);
            while (childrenQueue.Count > 1)
            {
                for (int i = 0; i < number - 1; i++)
                {
                    childrenQueue.Enqueue(childrenQueue.Dequeue());
                }

                Console.WriteLine("Removed " + childrenQueue.Dequeue());
            }

            Console.WriteLine("Last is " + childrenQueue.Dequeue());
        }
    }
}
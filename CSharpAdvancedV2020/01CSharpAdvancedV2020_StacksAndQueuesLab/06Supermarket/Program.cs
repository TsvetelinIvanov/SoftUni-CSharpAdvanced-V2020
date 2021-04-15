using System;
using System.Collections.Generic;

namespace _06Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> clientNames = new Queue<string>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input != "Paid")
                {
                    clientNames.Enqueue(input);
                }
                else
                {
                    while (clientNames.Count > 0)
                    {
                        Console.WriteLine(clientNames.Dequeue());
                    }
                }
            }

            Console.WriteLine($"{clientNames.Count} people remaining.");
        }
    }
}
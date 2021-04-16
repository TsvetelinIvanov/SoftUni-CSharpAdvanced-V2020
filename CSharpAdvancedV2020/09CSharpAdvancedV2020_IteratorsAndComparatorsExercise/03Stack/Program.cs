using System;
using System.Linq;

namespace _03Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> customStack = new CustomStack<int>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "Pop")
                {
                    customStack.Pop();
                }
                else
                {
                    int[] items = command.Split(" ", 2)[1].Split(", ").Select(int.Parse).ToArray();
                    foreach (int item in items)
                    {
                        customStack.Push(item);
                    }
                }
            }

            foreach (int item in customStack)
            {
                Console.WriteLine(item);
            }

            foreach (int item in customStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
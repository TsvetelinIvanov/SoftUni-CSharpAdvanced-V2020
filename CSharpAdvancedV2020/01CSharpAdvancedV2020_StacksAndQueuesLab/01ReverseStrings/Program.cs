using System;
using System.Collections.Generic;

namespace _01ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            Stack<char> charStack = new Stack<char>();
            foreach (char ch in inputString)
            {
                charStack.Push(ch);
            }

            while (charStack.Count != 0)
            {
                char currentChar = charStack.Pop();
                Console.Write(currentChar);
            }

            Console.WriteLine();
        }
    }
}
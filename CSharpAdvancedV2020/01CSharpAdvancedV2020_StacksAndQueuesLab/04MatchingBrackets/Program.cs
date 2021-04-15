using System;
using System.Collections.Generic;

namespace _04MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> bracketsIndexes = new Stack<int>();
            List<string> bracketsContents = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                if (ch == '(')
                {
                    bracketsIndexes.Push(i);
                }
                else if (ch == ')')
                {
                    int startIndex = bracketsIndexes.Pop();
                    string bracketsContent = input.Substring(startIndex, i - startIndex + 1);
                    bracketsContents.Add(bracketsContent);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, bracketsContents));
        }
    }
}
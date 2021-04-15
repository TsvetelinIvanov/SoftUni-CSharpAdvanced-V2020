using System;
using System.Collections.Generic;
using System.Text;

namespace _09SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int operationsCount = int.Parse(Console.ReadLine());
            Stack<string> oldVersions = new Stack<string>();
            //oldVersions.Push("");
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < operationsCount; i++)
            {
                string[] operation = Console.ReadLine().Split();
                int command = int.Parse(operation[0]);
                switch (command)
                {
                    case 1:
                        oldVersions.Push(text.ToString());
                        string someString = operation[1];
                        text.Append(someString);
                        break;
                    case 2:
                        oldVersions.Push(text.ToString());
                        int erasedLength = int.Parse(operation[1]);
                        text.Remove(text.Length - erasedLength, erasedLength);
                        break;
                    case 3:
                        int index = int.Parse(operation[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case 4:
                        text = new StringBuilder(oldVersions.Pop());
                        break;
                }
            }
        }
    }
}
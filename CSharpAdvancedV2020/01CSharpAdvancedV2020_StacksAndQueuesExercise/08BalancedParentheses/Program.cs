using System;
using System.Collections.Generic;

namespace _08BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();            
            if (input.Length / 2 == 0)
            {
                Console.WriteLine("NO");
                return;
            }

            Stack<char> parentheses = new Stack<char>();            
            for (int i = 0; i < input.Length; i++)
            {
                char parenthesis = input[i];
                switch (parenthesis)
                {
                    case '(':
                    case '[':
                    case '{':
                        parentheses.Push(parenthesis);
                        break;
                    case ')':
                        if (parentheses.Count == 0 || parentheses.Pop() != '(')
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                        break;
                    case ']':
                        if (parentheses.Count == 0 || parentheses.Pop() != '[')
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                        break;
                    case '}':
                        if (parentheses.Count == 0 || parentheses.Pop() != '{')
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                        break;
                }                
            }

            if (parentheses.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
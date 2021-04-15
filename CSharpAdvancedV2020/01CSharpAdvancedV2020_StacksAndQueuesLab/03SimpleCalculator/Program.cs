using System;
using System.Collections.Generic;
using System.Linq;

namespace _03SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string[] reversedInput = input.Reverse().ToArray();
            Stack<string> stack = new Stack<string>(reversedInput);
            while (stack.Count > 1)
            {
                int firstNumber = int.Parse(stack.Pop());
                string numberOperator = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());
                switch (numberOperator)
                {
                    case "+":
                        stack.Push((firstNumber + secondNumber).ToString());
                        break;
                    case "-":
                        stack.Push((firstNumber - secondNumber).ToString());
                        break;                    
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
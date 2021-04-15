using System;
using System.Collections.Generic;
using System.Linq;

namespace _02StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numbersStack = new Stack<int>(inputArray);
            string commandAndDataString; 
            while ((commandAndDataString = Console.ReadLine().ToLower()) != "end")
            {
                string[] commandAndDataArray = commandAndDataString.Split();
                string command = commandAndDataArray[0];
                if (command == "add")
                {
                    int firstNumber = int.Parse(commandAndDataArray[1]);
                    numbersStack.Push(firstNumber);
                    int secondNumber = int.Parse(commandAndDataArray[2]);
                    numbersStack.Push(secondNumber);
                }
                else if (command == "remove")
                {
                    int removedNumbersCount = int.Parse(commandAndDataArray[1]);
                    if (removedNumbersCount > numbersStack.Count)
                    {
                        continue;
                    }
                    else
                    {
                        for (int i = 0; i < removedNumbersCount; i++)
                        {
                            numbersStack.Pop();
                        }
                    }
                }                
            }

            int numbersStackSum = numbersStack.Sum();
            Console.WriteLine("Sum: " + numbersStackSum);
        }
    }
}
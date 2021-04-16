using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int claimedItemsCount = 0;
            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int firstNumber = firstBox.Peek();
                int secondNumber = secondBox.Peek();
                int sum = firstNumber + secondNumber;
                if (sum % 2 == 0)
                {
                    claimedItemsCount += sum;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            string boxName = string.Empty;
            if (firstBox.Count == 0)
            {
                boxName = "First ";
            }
            else if (secondBox.Count == 0)
            {
                boxName = "Second ";
            }

            string resultReport = "Your loot was epic!";
            if (claimedItemsCount < 100)
            {
                resultReport = "Your loot was poor...";
            }

            Console.WriteLine(boxName + "lootbox is empty");
            Console.WriteLine(resultReport + " Value: " + claimedItemsCount);
        }
    }
}
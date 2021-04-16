using System;

namespace _02GenericBoxOfInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int valuesNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < valuesNumber; i++)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                Console.WriteLine(box);
            }
        }
    }
}
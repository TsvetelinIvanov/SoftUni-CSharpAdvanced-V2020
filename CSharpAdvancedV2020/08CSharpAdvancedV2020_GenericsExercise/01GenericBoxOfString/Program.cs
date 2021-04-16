using System;

namespace _01GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int valuesNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < valuesNumber; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());
                Console.WriteLine(box);
            }
        }
    }
}
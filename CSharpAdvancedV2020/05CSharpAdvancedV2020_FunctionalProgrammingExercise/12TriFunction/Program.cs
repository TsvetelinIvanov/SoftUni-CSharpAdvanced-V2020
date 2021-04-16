using System;
using System.Linq;

namespace _12TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> isLarge = (name, number) =>
            {
                int nameNumber = 0;
                foreach (char character in name)
                {
                    nameNumber += (int)character;
                }

                return nameNumber >= number;
            };

            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            string name = names.First(n => isLarge(n, number));
            Console.WriteLine(name);
        }
    }
}
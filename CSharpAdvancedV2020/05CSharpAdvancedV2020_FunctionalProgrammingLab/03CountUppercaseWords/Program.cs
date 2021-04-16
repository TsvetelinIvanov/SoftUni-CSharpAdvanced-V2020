using System;
using System.Linq;

namespace _03CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> checker = w => w[0] == w.ToUpper()[0];
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(checker).ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
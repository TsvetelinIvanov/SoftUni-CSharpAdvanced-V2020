using System;
using System.Collections.Generic;
using System.Linq;

namespace _05CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> characters = new Dictionary<char, int>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                if (!characters.ContainsKey(input[i]))
                {
                    characters.Add(input[i], 0);
                }

                characters[input[i]]++;
            }

            characters = characters.OrderBy(ch => ch.Key).ToDictionary(ch => ch.Key, ch => ch.Value);
            foreach (KeyValuePair<char, int> characterCount in characters)
            {
                Console.WriteLine($"{characterCount.Key}: {characterCount.Value} time/s");
            }
        }
    }
}
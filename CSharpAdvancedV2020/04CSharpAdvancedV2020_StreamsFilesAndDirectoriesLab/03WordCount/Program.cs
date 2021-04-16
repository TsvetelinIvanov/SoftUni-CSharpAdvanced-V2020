using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllText("Words.txt").ToLower().Split();
            string[] text = File.ReadAllText("Input.txt").ToLower().Split(new char[] { '\n', '\r', ' ', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            foreach (string word in words)
            {
                wordsCount[word] = 0;
            }

            foreach (string word in text)
            {
                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                }
            }

            string output = string.Empty;
            foreach (KeyValuePair<string, int> word in wordsCount.OrderByDescending(w => w.Value))
            {
                //if (words.Contains(word.Key))
                //{
                //    if (word.Value == 0)
                //    {
                //        continue;
                //    }

                    output += $"{word.Key} - {word.Value}\r\n";
                //}
            }

            File.WriteAllText("Output.txt", output);
            //Console.WriteLine(output);
        }
    }
}
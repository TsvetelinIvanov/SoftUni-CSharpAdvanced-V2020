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
            string[] words = File.ReadAllLines("words.txt").Select(w => w.ToLower()).ToArray();
            string[] text = File.ReadAllText("text.txt").ToLower().Split(new char[] { '\n', '\r', ' ', '.', ',', '!', '?', '-', '_', '\'', '"', ':', ';', '(', ')', '[', ']', '{', '}', '/', '\\', '|', '`', '~', '^', '<', '>', '@', '#', '+', '=', '$', '%', '&', '*' }, StringSplitOptions.RemoveEmptyEntries);
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

            string actualResult = string.Empty;
            foreach (KeyValuePair<string, int> word in wordsCount)
            {                
                actualResult += $"{word.Key} - {word.Value}\r\n";                
            }

            string expectedResult = string.Empty;
            foreach (KeyValuePair<string, int> word in wordsCount.OrderByDescending(w => w.Value))
            {
                //if (words.Contains(word.Key))
                //{
                //    if (word.Value == 0)
                //    {
                //        continue;
                //    }

                expectedResult += $"{word.Key} - {word.Value}\r\n";
                //}
            }

            File.WriteAllText("actualResult.txt", actualResult);
            File.WriteAllText("expectedResult.txt", expectedResult);
            //Console.WriteLine(actualResult);
            //Console.WriteLine(expectedResult);
        }
    }
}
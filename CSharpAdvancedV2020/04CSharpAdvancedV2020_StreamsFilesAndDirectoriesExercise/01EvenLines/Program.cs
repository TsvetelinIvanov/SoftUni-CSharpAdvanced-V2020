using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            int lineNumber = 0;
            List<string> lines = new List<string>();
            string pattern = @"[-,.!?]";
            Regex regex = new Regex(pattern);
            string line = string.Empty;
            using (StreamReader reader = new StreamReader("text.txt"))
            {                
                while ((line = reader.ReadLine()) != null)
                {
                    if (lineNumber % 2 == 0)
                    {
                        line = regex.Replace(line, "@");
                        line = ReverseWords(line);
                        lines.Add(line);
                    }

                    lineNumber++;
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, lines));
        }

        private static string ReverseWords(string line)
        {
            string[] words = line.Split();
            string[] reversedWords = words.Reverse().ToArray();
            string reversedLine = string.Join(" ", reversedWords);

            return reversedLine;
        }
    }
}
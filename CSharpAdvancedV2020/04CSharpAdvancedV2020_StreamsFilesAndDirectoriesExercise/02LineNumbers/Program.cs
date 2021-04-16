using System;
using System.IO;
using System.Linq;

namespace _02LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("text.txt");
            char[] punctuationMarks = new char[] { '.', ',', '!', '?', '-', '_', '\'', '"', ':', ';', '(', ')', '[', ']', '{', '}', '/', '\\', '|', '`', '~', '^'};
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int lettersCount = 0;
                int punctuationMarksCount = 0;
                for (int j = 0; j < line.Length; j++)
                {
                    char character = line[j];
                    if (char.IsLetter(character))
                    {
                        lettersCount++;
                    }
                    else if (punctuationMarks.Contains(character))
                    {
                        punctuationMarksCount++;
                    }
                }

                string modifiedLine = $"Line {i + 1}: {line} ({lettersCount})({punctuationMarksCount})";
                lines[i] = modifiedLine;
            }

            string output = string.Join(Environment.NewLine, lines);
            File.WriteAllText("output.txt", output);
        }
    }
}
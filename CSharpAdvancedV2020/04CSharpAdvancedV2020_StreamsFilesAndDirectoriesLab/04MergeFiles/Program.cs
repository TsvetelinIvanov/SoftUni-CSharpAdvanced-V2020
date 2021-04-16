using System;
using System.IO;

namespace _04MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file1 = File.ReadAllLines("Input1.txt");
            string[] file2 = File.ReadAllLines("Input2.txt");
            string text = string.Empty;
            for (int i = 0; i < Math.Min(file1.Length, file2.Length); i++)
            {
                text += file1[i] + Environment.NewLine;
                text += file2[i] + Environment.NewLine;
            }

            for (int i = Math.Min(file1.Length, file2.Length); i < Math.Max(file1.Length, file2.Length); i++)
            {
                if (file1.Length > file2.Length)
                {
                    text += file1[i] + Environment.NewLine;
                }
                else
                {
                    text += file2[i] + Environment.NewLine;
                }
            }

            File.WriteAllText("Output.txt", text);
        }
    }
}
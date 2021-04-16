using System;
using System.Collections.Generic;
using System.IO;

namespace _05_SliceAFileModification //It adds exactly 2 lines in file 
{
    class Program
    {
        static void Main(string[] args)
        {            
            string sourceFile = "Input.txt"; //Add file path
            string[] lines = File.ReadAllLines(sourceFile); //The lines in sourceFile have to be in double file-parts count
            int parts = lines.Length / 2;
            if (lines.Length % 2 > 0)
            {
                parts++;
            }

            List<string> files = new List<string>();
            for (int i = 0; i < parts; i++)
            {
                string file = $"Part-{i + 1}.txt";
                files.Add(file);
            }
            
            using (FileStream streamReadFile = new FileStream(sourceFile, FileMode.Open))
            {
                long pieceSize = (long)Math.Ceiling((double)streamReadFile.Length / parts);
                int linesCount = 0;
                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;
                    using (FileStream streamCreateFile = new FileStream(files[i], FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];
                        while (streamReadFile.Read(buffer, 0, buffer.Length) == buffer.Length)
                        {
                            currentPieceSize += buffer.Length;
                            streamCreateFile.Write(buffer, 0, buffer.Length);
                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }

                    string[] currentLines = new string[2];
                    currentLines[0] = lines[linesCount];
                    linesCount++;
                    if (lines.Length < linesCount + 1)
                    {
                        currentLines[1] = "";
                    }
                    else
                    {
                        currentLines[1] = lines[linesCount];
                    }

                    File.WriteAllLines(files[i], currentLines);
                    linesCount++;

                    if (lines.Length < linesCount + 1)
                    {
                        break;
                    }
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05DirectoryTraversal//If cannot find TestFolder - Copy TestFolder in: 05DirectoryTraversal\bin\Debug\netcoreapp3.1 and comment GenerateTestDirectory(string directoryPath)!
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateTestDirectory("TestFolder"); //If they are errors - ignore them, they are unknown characters, the program works correctly!
            Dictionary<string, List<FileInfo>> extensionsAndFiles = new Dictionary<string, List<FileInfo>>();
            string[] fileNames = Directory.GetFiles("TestFolder");
            foreach (string fileName in fileNames)
            {
                FileInfo fileInfo = new FileInfo(fileName);
                string extension = fileInfo.Extension;
                if (!extensionsAndFiles.ContainsKey(extension))
                {
                    extensionsAndFiles.Add(extension, new List<FileInfo>());
                }

                if (!extensionsAndFiles[extension].Contains(fileInfo))
                {
                    extensionsAndFiles[extension].Add(fileInfo);
                }
            }

            extensionsAndFiles = extensionsAndFiles.OrderByDescending(ef => ef.Value.Count).ThenBy(ef => ef.Key)
                .ToDictionary(ef => ef.Key, ef => ef.Value);

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pathToReport = Path.Combine(desktopPath, "report.txt");
            using (StreamWriter writer = new StreamWriter(pathToReport, false))
            {
                foreach (string extension in extensionsAndFiles.Keys)
                {
                    writer.WriteLine(extension);
                    foreach (FileInfo fileInfo in extensionsAndFiles[extension].OrderBy(f => f.Length))
                    {
                        writer.WriteLine($"--{fileInfo.Name} - {fileInfo.Length / 1000d}kb");
                    }
                }
            }
        }

        private static void GenerateTestDirectory(string directoryPath)
        {
            Directory.CreateDirectory(directoryPath);
            Directory.CreateDirectory($"{directoryPath}{Path.DirectorySeparatorChar}bin");
            Directory.CreateDirectory($"{directoryPath}{Path.DirectorySeparatorChar}obj");
            Directory.CreateDirectory($"{directoryPath}{Path.DirectorySeparatorChar}Properties");

            string fileName = "Mecanismo.cs";
            string fileToCreate = Path.Combine(directoryPath, fileName);
            using (FileStream fileStream = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fileStream.SetLength(994);
            }

            fileName = "Program.cs";
            fileToCreate = Path.Combine(directoryPath, fileName);
            using (FileStream fileStream = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fileStream.SetLength(1108);
            }

            fileName = "Nashmat.cs";
            fileToCreate = Path.Combine(directoryPath, fileName);
            using (FileStream fileStream = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fileStream.SetLength(3967);
            }

            fileName = "Wedding.cs";
            fileToCreate = Path.Combine(directoryPath, fileName);
            using (FileStream fileStream = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fileStream.SetLength(23787);
            }

            fileName = "Program - Copy.cs";
            fileToCreate = Path.Combine(directoryPath, fileName);
            using (FileStream fileStream = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fileStream.SetLength(35679);
            }

            fileName = "Salimur.cs";
            fileToCreate = Path.Combine(directoryPath, fileName);
            using (FileStream fileStream = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fileStream.SetLength(588657);
            }

            fileName = "backup.txt";
            fileToCreate = Path.Combine(directoryPath, fileName);
            using (FileStream fileStream = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fileStream.SetLength(28);
            }

            fileName = "log.txt";
            fileToCreate = Path.Combine(directoryPath, fileName);
            using (FileStream fileStream = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fileStream.SetLength(6720);
            }

            fileName = "script.asm";
            fileToCreate = Path.Combine(directoryPath, fileName);
            using (FileStream fileStream = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fileStream.SetLength(28);
            }

            fileName = "App.config";
            fileToCreate = Path.Combine(directoryPath, fileName);
            using (FileStream fileStream = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fileStream.SetLength(187);
            }

            fileName = "01. Writing-To-Files.csproj";
            fileToCreate = Path.Combine(directoryPath, fileName);
            using (FileStream fileStream = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fileStream.SetLength(2570);
            }

            fileName = "controller.js";
            fileToCreate = Path.Combine(directoryPath, fileName);
            using (FileStream fileStream = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fileStream.SetLength(1635143);
            }

            fileName = "model.php";
            fileToCreate = Path.Combine(directoryPath, fileName);
            using (FileStream fileStream = new FileStream(fileToCreate, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fileStream.SetLength(0);
            }
        }
    }
}
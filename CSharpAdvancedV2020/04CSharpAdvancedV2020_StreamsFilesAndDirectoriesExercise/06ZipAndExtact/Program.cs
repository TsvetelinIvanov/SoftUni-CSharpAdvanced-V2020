using System;
using System.IO;
using System.IO.Compression;

namespace _06ZipAndExtact//Copy FolderForCopyMe on Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory("FolderForCopyMe", "FolderForCopyMyZipped.zip");//If the program throws System.IO.IOException delete FolderForCopyMyZipped.zip (because it already exists) from 06ZipAndExtact\bin\Debug\netcoreapp3.1
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pathToUnzip = Path.Combine(desktopPath, "FolderForCopyMyUnzipped");
            ZipFile.ExtractToDirectory("FolderForCopyMyZipped.zip", pathToUnzip);
        }
    }
}
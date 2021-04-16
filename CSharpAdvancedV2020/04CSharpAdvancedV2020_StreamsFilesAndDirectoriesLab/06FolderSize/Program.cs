using System.IO;

namespace _06FolderSize//If cannot find TestFolder - Copy TestFolder in: 06FolderSize\bin\Debug\netcoreapp3.1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("TestFolder");
            double sum = 0;
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }

            double sumInMegabytes = sum / 1024 / 1024;
            File.WriteAllText("Output.txt", sumInMegabytes.ToString());
        }
    }
}
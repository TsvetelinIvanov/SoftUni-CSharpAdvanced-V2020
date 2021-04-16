using System;
using System.IO;

namespace _04CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream reader = new FileStream("copyMe.png", FileMode.Open, FileAccess.Read))
            {
                using (FileStream writer = new FileStream("copy.png", FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[4096];
                    int readBytes = reader.Read(buffer, 0, buffer.Length);
                    while (readBytes != 0)
                    {
                        writer.Write(buffer, 0, readBytes);
                        readBytes = reader.Read(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
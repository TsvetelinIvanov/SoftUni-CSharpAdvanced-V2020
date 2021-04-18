using System;

namespace _03OpenClosed_FileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            File file = new File("TestFile");
            file.Length = 100;
            file.Sent = 17;
            Progress progressFile = new Progress(file);
            Console.WriteLine(progressFile.CurrentPercent());//17

            Music music = new Music("Manowar", "Defender");
            music.Length = 50;
            music.Sent = 10;
            Progress progressMusic = new Progress(music);
            Console.WriteLine(progressMusic.CurrentPercent());//20
        }
    }
}
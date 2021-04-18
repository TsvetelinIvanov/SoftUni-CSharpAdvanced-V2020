using System;

namespace _01StreamProgressInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            File file = new File("TestFile", 100, 15);
            Music music = new Music("Rammstein", "Deutschland", 50, 10);

            StreamProgressInfo streamProgressInfoFile = new StreamProgressInfo(file);
            StreamProgressInfo streamProgressInfoMusic = new StreamProgressInfo(music);

            Console.WriteLine(streamProgressInfoFile.CalculateCurrentPercent());
            Console.WriteLine(streamProgressInfoMusic.CalculateCurrentPercent());
        }
    }
}
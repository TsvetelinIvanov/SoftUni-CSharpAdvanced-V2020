using System;

namespace _16BehavioralPatterns_Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            INewspaper nyp = new NYPaper();
            INewspaper lap = new LAPaper();

            IIterator nypIterator = nyp.CreateIterator();
            IIterator lapIterator = lap.CreateIterator();

            Console.WriteLine("--------   NYPaper");//--------   NYPaper
            PrintReporters(nypIterator);
            //John Mesh - NY
            //Susanna Lee -NY
            //Paul Randy -NY
            //Kim Fields -NY
            //Sky Taylor -NY

            Console.WriteLine("--------   LAPaper");//--------   LAPaper
            PrintReporters(lapIterator);
            //Ronald Smith - LA
            //Danny Glover -LA
            //Yolanda Adams -LA
            //Jerry Straight -LA
            //Rhonda Lime -LA
        }

        public static void PrintReporters(IIterator iterator)
        {
            iterator.First();

            while (!iterator.IsDone())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }
}
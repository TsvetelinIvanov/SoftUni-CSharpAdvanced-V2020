using System;

namespace _05DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            DateModifier dateModifier = new DateModifier();
            int dayDifference = dateModifier.CalculateDayDifference(firstDate, secondDate);
            Console.WriteLine(dayDifference);
        }
    }
}
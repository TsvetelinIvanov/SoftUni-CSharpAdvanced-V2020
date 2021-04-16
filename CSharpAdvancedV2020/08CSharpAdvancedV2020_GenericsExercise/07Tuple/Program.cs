using System;

namespace _07Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nameAndAddress = Console.ReadLine().Split();
            string name = nameAndAddress[0] + " " + nameAndAddress[1];
            string address = nameAndAddress[2];
            Tuple<string, string> nameAndAddressTuple = new Tuple<string, string>(name, address);

            string[] nameAndBeer = Console.ReadLine().Split();
            string firstName = nameAndBeer[0];
            int beerCount = int.Parse(nameAndBeer[1]);
            Tuple<string, int> nameAndBeerTuple = new Tuple<string, int>(firstName, beerCount);

            string[] numbers = Console.ReadLine().Split();
            int intNumber = int.Parse(numbers[0]);
            double doubleNumber = double.Parse(numbers[1]);
            Tuple<int, double> numbersTuple = new Tuple<int, double>(intNumber, doubleNumber);

            Console.WriteLine(nameAndAddressTuple.Item1 + " -> " + nameAndAddressTuple.Item2);
            Console.WriteLine(nameAndBeerTuple.Item1 + " -> " + nameAndBeerTuple.Item2);
            Console.WriteLine(numbersTuple.Item1 + " -> " + numbersTuple.Item2);
        }
    }
}
using System;

namespace _08Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nameAndAddress = Console.ReadLine().Split(" ", 4);
            string name = nameAndAddress[0] + " " + nameAndAddress[1];
            string address = nameAndAddress[2];
            string town = nameAndAddress[3];
            Threeuple<string, string, string> nameAndAddressThreeple = new Threeuple<string, string, string>(name, address, town);

            string[] nameAndBeer = Console.ReadLine().Split();
            string firstName = nameAndBeer[0];
            int beerCount = int.Parse(nameAndBeer[1]);
            bool isDrunk = false;
            if (nameAndBeer[2] == "drunk")
            {
                isDrunk = true;
            }
            else if (nameAndBeer[2] == "not")
            {
                isDrunk = false;
            }

            Threeuple<string, int, bool> nameAndBeerThreeple = new Threeuple<string, int, bool>(firstName, beerCount, isDrunk);

            string[] bankData = Console.ReadLine().Split();
            string clientName = bankData[0];
            double accountBalance = double.Parse(bankData[1]);
            string bankName = bankData[2];
            Threeuple<string, double, string> bankDataThreeple = new Threeuple<string, double, string>(clientName, accountBalance, bankName);

            Console.WriteLine(nameAndAddressThreeple.Item1 + " -> " + nameAndAddressThreeple.Item2 + " -> " + nameAndAddressThreeple.Item3);
            Console.WriteLine(nameAndBeerThreeple.Item1 + " -> " + nameAndBeerThreeple.Item2 + " -> " + nameAndBeerThreeple.Item3);
            Console.WriteLine(bankDataThreeple.Item1 + " -> " + bankDataThreeple.Item2 + " -> " + bankDataThreeple.Item3);
        }
    }
}
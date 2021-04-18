using System;

namespace _03CreationalPatterns_FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ICreditUnionFactory factory = new SavingsAcctFactory() as ICreditUnionFactory;
            ISavingsAccount cityAcct = factory.GetSavingsAccount("CITY-321");
            ISavingsAccount nationalAcct = factory.GetSavingsAccount("NATIONAL-987");

            Console.WriteLine($"My city balance is ${cityAcct.Balance}" + $" and national balance is {nationalAcct.Balance}.");//My city balance is $5000 and national balance is 2000.
        }
    }
}
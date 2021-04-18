using System;
using System.Collections.Generic;

namespace _04CreationalPatterns_AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> accntNumbers = new List<string> 
            {
                "CITI-456",
                "NATIONAL-987",
                "CHASE-222" 
            };

            for (int i = 0; i < accntNumbers.Count; i++)
            {
                ICreditUnionFactory anAbstractFactory = CreditUnionFactoryProvider.GetCreditUnionFactory(accntNumbers[i]);
                if (anAbstractFactory == null)
                {
                    string accNumber = accntNumbers[i];
                    Console.WriteLine($"Sorry. The account number {accNumber} is invalid.");
                }
                else
                {
                    ILoanAccount loan = anAbstractFactory.CreateLoanAccount();
                    ISavingsAccount savings = anAbstractFactory.CreateSavingsAccount();

                    string accNumber = accntNumbers[i];
                    Console.WriteLine($"The account number {accNumber} is successfull validated.");
                }

                //The account number CITI-456 is successfull validated.
                //The account number NATIONAL-987 is successfull validated.
                //Sorry.The account number CHASE-222 is invalid.
            }
        }
    }
}
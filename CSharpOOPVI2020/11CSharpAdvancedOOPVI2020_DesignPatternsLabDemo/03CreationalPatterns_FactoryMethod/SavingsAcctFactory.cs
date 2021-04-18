using System;

namespace _03CreationalPatterns_FactoryMethod
{
    public class SavingsAcctFactory : ICreditUnionFactory
    {
        public ISavingsAccount GetSavingsAccount(string acctNo)
        {
            if (acctNo.Contains("CITY"))
            {
                return new CitySavingsAcct();
            }

            if (acctNo.Contains("NATIONAL"))
            {
                return new NationalSavingsAcct();
            }

            throw new ArgumentException("Invalid Account Number");
        }
    }
}
namespace _03CreationalPatterns_FactoryMethod
{
    public class NationalSavingsAcct : ISavingsAccount
    {
        public NationalSavingsAcct()
        {
            this.Balance = 2000;
        }

        public decimal Balance { get; set; }
    }
}
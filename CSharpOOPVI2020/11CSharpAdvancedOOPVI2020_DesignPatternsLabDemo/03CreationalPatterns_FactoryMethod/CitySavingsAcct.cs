namespace _03CreationalPatterns_FactoryMethod
{
    public class CitySavingsAcct : ISavingsAccount
    {
        public CitySavingsAcct()
        {
            this.Balance = 5000;
        }

        public decimal Balance { get; set; }
    }
}
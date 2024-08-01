namespace _22BehavioralPatterns_State
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account("John Smith");

            account.Deposit(490.0);
            //Deposited 490,00 лв. ---
            //Balance = 490,00 лв.
            //Status = StandardState
            
            account.Deposit(390.0);
            //Deposited 390,00 лв. ---
            //Balance = 880,00 лв.
            //Status = StandardState
            
            account.Deposit(540.0);
            //Deposited 540,00 лв. ---
            //Balance = 1 420,00 лв.
            //Status = PremiumState
            
            account.PayInterest();
            //Interest Paid ---
            //Balance = 1 491,00 лв.
            //Status = PremiumState
            
            account.Withdraw(2200.0);
            //Withdrew 2 200,00 лв. ---
            //Balance = -709,00 лв.
            //Status = OverdrawnState
            
            account.Withdraw(1300.0);
            //No funds available for withdrawal!
            //Withdrew 1 300,00 лв. -- -
            //Balance = -709,00 лв.
            //Status = OverdrawnState
        }
    }
}

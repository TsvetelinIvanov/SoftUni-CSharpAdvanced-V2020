using System;

namespace _08StructuralPatterns_Facade
{
    public class CollegeLoan
    {
        private Bank bank;
        private Loan loan;
        private Credit credit;

        public CollegeLoan()
        {
            this.bank = new Bank();
            this.loan = new Loan();
            this.credit = new Credit();
        }

        public bool IsEligible(Student student, int amount)
        {
            Console.WriteLine("{0} applies for {1:C} loan\n", student.Name, amount);

            bool eligible = true;

            // Verify creditworthyness of applicant
            if (!bank.HasSufficientSavings(student, amount))
            {
                eligible = false;
            }
            else if (!loan.HasNoBadLoans(student))
            {
                eligible = false;
            }
            else if (!credit.HasGoodCredit(student))
            {
                eligible = false;
            }

            return eligible;
        }
    }
}
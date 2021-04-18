using System;

namespace _08StructuralPatterns_Facade
{
    public class Loan
    {
        public bool HasNoBadLoans(Student student)
        {
            Console.WriteLine("Verify loans for " + student.Name);

            return true;
        }
    }
}
using System;

namespace _08StructuralPatterns_Facade
{
    public class Bank
    {
        public bool HasSufficientSavings(Student student, int amount)
        {
            Console.WriteLine("Verify bank for " + student.Name);

            return true;
        }
    }
}
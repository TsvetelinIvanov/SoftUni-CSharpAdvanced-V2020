using System;

namespace _08StructuralPatterns_Facade
{
    public class Credit
    {
        public bool HasGoodCredit(Student student)
        {
            Console.WriteLine("Verify credit for " + student.Name);

            return true;
        }
    }
}
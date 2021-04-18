using System;

namespace _08StructuralPatterns_Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CollegeLoan collegeLoan = new CollegeLoan();

            Student student = new Student("Hunter Sky");
            bool eligible = collegeLoan.IsEligible(student, 75000);//Hunter Sky applies for 75 000, 00 лв.loan
            //Verify bank for Hunter Sky
            //Verify loans for Hunter Sky
            //Verify credit for Hunter Sky

            Console.WriteLine(Environment.NewLine + student.Name + " has been " + (eligible ? "Approved" : "Rejected"));//Hunter Sky has been Approved
        }
    }
}
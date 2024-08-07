﻿using System;

namespace _09StructuralPatterns_Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee peter = new Employee { EmployeeID = 1, Name = "peter", Rating = 3 };

            Employee george = new Employee { EmployeeID = 2, Name = "george", Rating = 4 };

            Employee john = new Employee { EmployeeID = 3, Name = "john", Rating = 5 };

            Employee adam = new Employee { EmployeeID = 4, Name = "adam", Rating = 3 };

            Employee martin = new Employee { EmployeeID = 5, Name = "martin", Rating = 4 };

            Employee jenny = new Employee { EmployeeID = 6, Name = "jenny", Rating = 5 };

            Supervisor michael = new Supervisor { EmployeeID = 7, Name = "michael", Rating = 3 };

            Supervisor justin = new Supervisor { EmployeeID = 8, Name = "justin", Rating = 3 };

            michael.AddSubordinate(peter);
            michael.AddSubordinate(george);
            michael.AddSubordinate(john);

            justin.AddSubordinate(adam);
            justin.AddSubordinate(martin);
            justin.AddSubordinate(jenny);

            Console.WriteLine($"{Environment.NewLine}--- Employee can see their Performance " + "Summary --------");//--- Employee can see their Performance Summary --------
            peter.PerformanceSummary();//Performance summary of employee: peter is 3 out of 5

            Console.WriteLine($"{Environment.NewLine}--- Supervisor can also see their " + "subordinates performance summary-----");//--- Supervisor can also see their subordinates performance summary-----
            michael.PerformanceSummary();//Performance summary of supervisor: michael is 3 out of 5

            Console.WriteLine($"{Environment.NewLine}Subordinate Performance Record:");//Subordinate Performance Record:
            foreach (IEmployee employee in michael.ListSubordinates)
            {
                employee.PerformanceSummary();
            }

            //Performance summary of employee: peter is 3 out of 5
            //Performance summary of employee: george is 4 out of 5
            //Performance summary of employee: john is 5 out of 5
        }
    }
}
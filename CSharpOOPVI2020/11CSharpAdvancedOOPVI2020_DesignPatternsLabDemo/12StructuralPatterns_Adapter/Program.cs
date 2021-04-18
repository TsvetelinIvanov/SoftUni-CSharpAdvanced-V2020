using System;

namespace _12StructuralPatterns_Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee list from 3rd party organization system.");//Employee list from 3rd party organization system.
            Console.WriteLine("-------------------------------------------------");//-------------------------------------------------

            ITarget adapter = new EmployeeAdapter();
            foreach (string employee in adapter.GetEmployees())
            {
                Console.WriteLine(employee);
            }

            //Peter
            //Paul
            //Puru
            //Preethi
        }
    }
}
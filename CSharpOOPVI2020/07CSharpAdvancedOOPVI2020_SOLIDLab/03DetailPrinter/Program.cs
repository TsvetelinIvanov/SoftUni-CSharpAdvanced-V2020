using System.Collections.Generic;

namespace _03DetailPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Ivan Ivanov");
            Manager manager = new Manager("Ivan Dimitrov", new string[] { "Workers list", "Salaries list" });
            List<Employee> employees = new List<Employee>(new Employee[] { employee, manager });
            DetailsPrinter detailsPrinter = new DetailsPrinter(employees);
            detailsPrinter.PrintDetails();
        }
    }
}
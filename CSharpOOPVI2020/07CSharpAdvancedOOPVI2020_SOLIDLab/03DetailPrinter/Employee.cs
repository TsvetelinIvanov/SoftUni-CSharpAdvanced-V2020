using System;

namespace _03DetailPrinter
{
    public class Employee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public virtual void PrintDetails()
        {
            Console.WriteLine(this.Name);
        }
    }
}
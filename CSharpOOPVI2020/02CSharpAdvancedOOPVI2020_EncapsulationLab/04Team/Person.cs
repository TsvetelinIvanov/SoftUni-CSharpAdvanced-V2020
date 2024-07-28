using System;

namespace PersonsInfo
{
    public class Person
    {
        private const int MinNameLength = 3;
        private const int MinAge = 1;
        private const decimal MinSalary = 460;

        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;
        
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value.Length < MinNameLength)
                {
                    throw new ArgumentException($"First name cannot contain fewer than {MinNameLength} symbols!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value.Length < MinNameLength)
                {
                    throw new ArgumentException($"Last name cannot contain fewer than {MinNameLength} symbols!");
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < MinAge)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                this.age = value;
            }
        }

        public decimal Salary
        {
            get { return this.salary; }
            private set
            {
                if (value < MinSalary)
                {
                    throw new ArgumentException($"Salary cannot be less than {MinSalary} leva!");
                }

                this.salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age > 30)
            {
                this.Salary += this.Salary * percentage / 100;
            }
            else
            {
                this.Salary += this.Salary * percentage / 200;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }
    }
}

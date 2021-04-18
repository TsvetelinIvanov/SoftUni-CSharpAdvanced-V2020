using System;
using System.Text.RegularExpressions;

namespace _07CustomException
{
    public class Student : Person
    {
        private const int MinEmailLength = 3;
        private const string namePattern = "^[a-z A-Z]+$";

        private string name;
        private string email;

        public Student(string firstName, string lastName, int age, string email) : base(firstName, lastName, age)
        {
            this.Name = firstName + " " + lastName;
            this.Email = email;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                Regex regex = new Regex(namePattern);
                if (!regex.IsMatch(value))
                {
                    throw new InvalidPersonNameException();
                }

                this.name = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (!value.Contains("@") || value.Length < MinEmailLength)
                {
                    throw new ArgumentException($"Invalid email - \"{value}\"! It must contains \"@\" and be at least {MinEmailLength} long!");
                }

                this.email = value;
            }
        }
    }
}
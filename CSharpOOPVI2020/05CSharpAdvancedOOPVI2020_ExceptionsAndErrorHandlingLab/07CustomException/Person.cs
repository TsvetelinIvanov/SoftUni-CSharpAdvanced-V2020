using System;

namespace _07CustomException
{
    public class Person
    {
        private const int MinAge = 0;
        private const int MaxAge = 120;

        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "The first name cannot not be null or empty!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "The last name cannot not be null or empty!");
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new ArgumentOutOfRangeException("value", $"The age {value} can't be real! It must be between {MinAge} and {MaxAge} years!");
                }

                this.age = value;
            }
        }
    }
}

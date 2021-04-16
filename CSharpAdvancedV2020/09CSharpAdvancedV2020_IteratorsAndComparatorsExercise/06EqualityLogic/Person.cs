using System;

namespace _06EqualityLogic 
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;            
        }

        public string Name { get; private set; }

        public int Age { get; private set; }        

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                Person objAsPerson = obj as Person;

                return this.Name == objAsPerson.Name && this.Age == objAsPerson.Age;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Age);
        }
    }
}
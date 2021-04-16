using System;
using System.Collections.Generic;
using System.Linq;

namespace _05ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] personData = input.Split();
                string name = personData[0];
                int age = int.Parse(personData[1]);
                string town = personData[2];
                Person person = new Person(name, age, town);
                people.Add(person);
            }

            int comparingPersonNumber = int.Parse(Console.ReadLine());
            Person comparingPerson = people[comparingPersonNumber - 1];

            int equalPeopleCount = people.Where(p => p.CompareTo(comparingPerson) == 0).Count();
            int unequalPeopleCount = people.Where(p => p.CompareTo(comparingPerson) != 0).Count();
            int allPeopleCount = people.Count;

            if (equalPeopleCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(equalPeopleCount + " " + unequalPeopleCount + " " + allPeopleCount);
            }
        }
    }
}
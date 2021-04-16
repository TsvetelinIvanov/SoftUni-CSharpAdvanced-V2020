using System;
using System.Collections.Generic;

namespace _06EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> people = new HashSet<Person>();
            SortedSet<Person> orderedPeople = new SortedSet<Person>();
            int peopleNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < peopleNumber; i++)
            {
                string[] personData = Console.ReadLine().Split();
                string name = personData[0];
                int age = int.Parse(personData[1]);
                Person person = new Person(name, age);
                people.Add(person);
                orderedPeople.Add(person);                
            }

            Console.WriteLine(people.Count);
            Console.WriteLine(orderedPeople.Count);
        }
    }
}
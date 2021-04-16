using System;
using System.Collections.Generic;
using System.Linq;

namespace _04OpinionPoll
{
    public class Program
    {
        static void Main(string[] args)
        {
            int peopleNumber = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < peopleNumber; i++)
            {
                string[] personData = Console.ReadLine().Split();
                string name = personData[0];
                int age = int.Parse(personData[1]);
                Person person = new Person(name, age);
                people.Add(person);
            }

            List<Person> peopleOver30 = people.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();
            peopleOver30.ForEach(p => Console.WriteLine(p.Name + " - " + p.Age));
        }
    }
}
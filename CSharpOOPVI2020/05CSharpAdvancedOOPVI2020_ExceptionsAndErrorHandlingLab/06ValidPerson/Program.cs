using System;
using System.Collections.Generic;

namespace _06ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstNames = new string[] { "Pesho", "  ", "Gosho", "Stamat", "Prakash", "Yolo", "Ivan" };
            string[] lasttNames = new string[] { "Peshev", "Goshev", "", null, "Penchev", "Delev", "Ivanov" };
            int[] ages = new int[] { 31, 27, 15, 18, -19, 121, 40 };
            List<Person> people = new List<Person>();
            for (int i = 0; i < 7; i++)
            {
                try
                {
                    Person person = new Person(firstNames[i], lasttNames[i], ages[i]);
                    people.Add(person);
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("Exception thrown: " + ane.Message);
                }
                catch (ArgumentOutOfRangeException aoore)
                {
                    Console.WriteLine("Exception thrown: " + aoore.Message);
                }
            }

            people.ForEach(p => Console.WriteLine($"Name: {p.FirstName} {p.LastName}, age: {p.Age}."));
        }
    }
}
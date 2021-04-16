using System;
using System.Collections.Generic;

namespace _05FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> people = new Dictionary<string, int>();
            int peopleCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < peopleCount; i++)
            {
                string[] nameAndAge = Console.ReadLine().Split(", ");
                string name = nameAndAge[0];
                int personAge = int.Parse(nameAndAge[1]);
                people.Add(name, personAge);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, age);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);
            PrintFilterdPeople(people, tester, printer);
        }

        private static Func<int, bool> CreateTester(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return a => a < age;
                case "older":
                    return a => a >= age;
                default:
                    return null;
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine(person.Key);
                case "age":
                    return person => Console.WriteLine(person.Value);
                case "name age":
                    return person => Console.WriteLine(person.Key + " - " + person.Value);
                default:
                    return null;
            }
        }

        private static void PrintFilterdPeople(Dictionary<string, int> people, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            foreach (KeyValuePair<string, int> person in people)
            {
               if (tester(person.Value))
                {
                    printer(person);
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace _10PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, bool> startsWith = (name, str) => name.StartsWith(str);
            Func<string, string, bool> endsWith = (name, str) => name.EndsWith(str);
            Func<string, string, bool> isInLength = (name, length) => name.Length == int.Parse(length);
            List<string> guests = Console.ReadLine().Split().ToList();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] commandLine = input.Split();
                string command = commandLine[0];
                string criteria = commandLine[1];
                string argument = commandLine[2];

                Func<string, string, bool> applyCriteria = null;
                switch (criteria)
                {
                    case "StartsWith":
                        applyCriteria = startsWith;
                        break;
                    case "EndsWith":
                        applyCriteria = endsWith;
                        break;
                    case "Length":
                        applyCriteria = isInLength;
                        break;
                }

                switch (command)
                {
                    case "Double":
                        List<string> currentGuests = new List<string>();
                        foreach (string guest in guests)
                        {
                            if (applyCriteria(guest, argument))
                            {
                                currentGuests.Add(guest);
                            }

                            currentGuests.Add(guest);
                        }

                        guests = currentGuests;
                        break;
                    case "Remove":
                        List<string> removedGuests = new List<string>();
                        foreach (string guest in guests)
                        {                            
                            if (applyCriteria(guest, argument))
                            {
                                removedGuests.Add(guest);
                            }
                        }

                        foreach (string removedGuest in removedGuests)
                        {
                            guests.Remove(removedGuest);
                        }

                        break;
                }
            }

            if (guests.Any())
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
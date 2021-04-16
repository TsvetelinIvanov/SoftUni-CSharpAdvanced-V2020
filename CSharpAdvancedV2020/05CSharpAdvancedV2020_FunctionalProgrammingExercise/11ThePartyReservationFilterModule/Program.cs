using System;
using System.Collections.Generic;
using System.Linq;

namespace _11ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Func<string, bool>> filters = new Dictionary<string, Func<string, bool>>();
            string[] guests = Console.ReadLine().Split();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] commandLine = input.Split(";", 2);
                string command = commandLine[0].Split().First();
                string filterData = commandLine[1];
                if (command == "Add")
                {
                    Func<string, bool> filter = CreateFilter(filterData);
                    filters.Add(filterData, filter);
                }
                else if (command == "Remove")
                {
                    filters.Remove(filterData);
                }
            }

            foreach (KeyValuePair<string, Func<string, bool>> filter in filters)
            {
                guests = guests.Where(filter.Value).ToArray();
            }

            Console.WriteLine(string.Join(" ", guests));
        }

        private static Func<string, bool> CreateFilter(string filterData)
        {
            Func<string, bool> filter = null;
            string filterType = filterData.Split(";").First();
            string filterArgument = filterData.Split(";").Last();
            switch (filterType)
            {
                case "Starts with":
                    filter = name => !name.StartsWith(filterArgument);
                    break;
                case "Ends with":
                    filter = name => !name.EndsWith(filterArgument);
                    break;
                case "Contains":
                    filter = name => !name.Contains(filterArgument);
                    break;
                case "Length":
                    filter = name => name.Length != int.Parse(filterArgument);
                    break;
            }

            return filter;
        }
    }
}
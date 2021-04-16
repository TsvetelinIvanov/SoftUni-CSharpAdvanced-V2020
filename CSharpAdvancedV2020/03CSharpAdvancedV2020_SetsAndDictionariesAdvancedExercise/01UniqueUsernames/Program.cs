using System;
using System.Collections.Generic;

namespace _01UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>();
            int usernamesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < usernamesCount; i++)
            {
                string username = Console.ReadLine();
                usernames.Add(username);
            }

            foreach (string username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
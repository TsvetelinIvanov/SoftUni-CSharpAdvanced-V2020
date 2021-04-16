using System;
using System.Collections.Generic;
using System.Linq;

namespace _07TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>[]> vloggers = new Dictionary<string, HashSet<string>[]>();
            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] inputLine = input.Split();        
                string command = inputLine[1];

                if (command == "joined" && !vloggers.ContainsKey(inputLine[0]))
                {
                    string vlogger = inputLine[0];
                    vloggers.Add(vlogger, new HashSet<string>[2]);
                    vloggers[vlogger][0] = new HashSet<string>();
                    vloggers[vlogger][1] = new HashSet<string>();
                }
                else if (command == "followed" && vloggers.ContainsKey(inputLine[0]) && vloggers.ContainsKey(inputLine[2]) && inputLine[0] != inputLine[2])
                {
                    string follower = inputLine[0];
                    string vlogger = inputLine[2];
                    vloggers[vlogger][0].Add(follower);
                    vloggers[follower][1].Add(vlogger);
                }
            }

            int vloggersCount = vloggers.Count;
            vloggers = vloggers.OrderByDescending(v => v.Value[0].Count).ThenBy(v => v.Value[1].Count).ToDictionary(v => v.Key, v => v.Value);

            Console.WriteLine($"The V-Logger has a total of {vloggersCount} vloggers in its logs.");
            if (vloggers.First().Value[0].Count == 0)
            {               
                return;
            }

            int vloggerNumber = 0;
            foreach (KeyValuePair<string, HashSet<string>[]> vlogger in vloggers)
            {
                vloggerNumber++;
                string vloggerName = vlogger.Key;
                int followersCount = vlogger.Value[0].Count;
                int followingCount = vlogger.Value[1].Count;
                Console.WriteLine($"{vloggerNumber}. {vloggerName} : {followersCount} followers, {followingCount} following");
                if (vloggerNumber == 1)
                {
                    HashSet<string> followers = vlogger.Value[0];
                    foreach (string follower in followers.OrderBy(f => f))
                    {
                        Console.WriteLine("*  " + follower);
                    }
                }
            }
        }
    }
}
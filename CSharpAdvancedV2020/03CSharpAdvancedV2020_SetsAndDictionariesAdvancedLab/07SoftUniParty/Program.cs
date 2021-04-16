using System;
using System.Collections.Generic;

namespace _07SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            HashSet<string> vipGuests = new HashSet<string>();
            string reservationNumber;
            while ((reservationNumber = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(reservationNumber[0]))
                {
                    vipGuests.Add(reservationNumber);
                }
                else
                {
                    guests.Add(reservationNumber);
                }
            }

            string commingGuest;
            while ((commingGuest = Console.ReadLine()) != "END")
            {
                if (vipGuests.Contains(commingGuest))
                {
                    vipGuests.Remove(commingGuest);
                }
                else if (guests.Contains(commingGuest))
                {
                    guests.Remove(commingGuest);
                }
            }

            int notCommingGuestsCount = vipGuests.Count + guests.Count;
            Console.WriteLine(notCommingGuestsCount);
            foreach (string guest in vipGuests)
            {
                Console.WriteLine(guest);
            }

            foreach (string guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
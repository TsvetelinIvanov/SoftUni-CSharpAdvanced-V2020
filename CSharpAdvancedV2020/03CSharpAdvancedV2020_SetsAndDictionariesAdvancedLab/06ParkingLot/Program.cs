using System;
using System.Collections.Generic;
using System.Linq;

namespace _06ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();
            string input;
            while((input = Console.ReadLine()) != "END")
            {
                string command = input.Split(", ").First();
                string car = input.Split(", ").Last();
                if (command == "IN")
                {
                    parking.Add(car);
                }
                else if (command == "OUT")
                {
                    parking.Remove(car);
                }
            }

            if (parking.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, parking));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
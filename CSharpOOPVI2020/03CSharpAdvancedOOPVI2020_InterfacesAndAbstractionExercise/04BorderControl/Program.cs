using System;
using System.Collections.Generic;

namespace _04BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> passengers = new List<IIdentifiable>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] passengerData = input.Split();
                if (passengerData.Length == 3)
                {
                    string name = passengerData[0];
                    int age = int.Parse(passengerData[1]);
                    string id = passengerData[2];
                    Citizen citizen = new Citizen(id, name, age);
                    passengers.Add(citizen);
                }
                else if (passengerData.Length == 2)
                {
                    string model = passengerData[0];
                    string id = passengerData[1];
                    Robot robot = new Robot(id, model);
                    passengers.Add(robot);
                }
                else
                {
                    throw new ArgumentException("Invalid count of arguments!");
                }
            }
            
            string fakeIdEnding = Console.ReadLine();
            foreach (IIdentifiable passenger in passengers)
            {
                if (passenger.Id.EndsWith(fakeIdEnding))
                {
                    Console.WriteLine(passenger.Id);
                }
            }
        }
    }
}
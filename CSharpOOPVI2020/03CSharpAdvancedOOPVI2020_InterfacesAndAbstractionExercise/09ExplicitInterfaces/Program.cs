using System;

namespace _09ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] citizenData = input.Split();
                string name = citizenData[0];
                string country = citizenData[1];
                int age = int.Parse(citizenData[2]);
                Citizen citizen = new Citizen(name, age, country);
                Console.WriteLine(citizen.GetName());
                //IResident resident = new Citizen(name, age, country);
                //Console.WriteLine(resident.GetName());
                Console.WriteLine((citizen as IResident).GetName());
            }            
        }
    }
}
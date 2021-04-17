using System;
using System.Collections.Generic;

namespace _05BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> inhabitants = new List<IBirthable>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inhabitantData = input.Split();
                string inhabitantKind = inhabitantData[0];
                if (inhabitantKind == "Citizen")
                {
                    string name = inhabitantData[1];
                    int age = int.Parse(inhabitantData[2]);
                    string id = inhabitantData[3];
                    string birthdate = inhabitantData[4];
                    Citizen citizen = new Citizen(id, name, age, birthdate);
                    inhabitants.Add(citizen);
                }
                else if (inhabitantKind == "Pet")
                {
                    string name = inhabitantData[1];
                    string birthdate = inhabitantData[2];
                    Pet pet = new Pet(name, birthdate);
                    inhabitants.Add(pet);
                }                
            }

            string birthYear = Console.ReadLine();
            foreach (IBirthable inhabitant in inhabitants)
            {
                if (inhabitant.Birthdate.EndsWith(birthYear))
                {
                    Console.WriteLine(inhabitant.Birthdate);
                }
            }
        }
    }
}
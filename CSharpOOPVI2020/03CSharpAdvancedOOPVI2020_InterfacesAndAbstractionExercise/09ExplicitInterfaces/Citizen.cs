﻿namespace _09ExplicitInterfaces
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, int age, string country)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }        

        public string Country { get; private set; }

        public string GetName()
        {
            return this.Name;
        }

        string IResident.GetName()
        {
            return "Mr/Ms/Mrs " + this.Name;
        }
    }
}
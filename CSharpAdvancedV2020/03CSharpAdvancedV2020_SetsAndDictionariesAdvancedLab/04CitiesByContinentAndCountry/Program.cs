using System;
using System.Collections.Generic;

namespace _04CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continentsData = new Dictionary<string, Dictionary<string, List<string>>>();
            int lineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < lineCount; i++)
            {
                string[] inputData = Console.ReadLine().Split();
                string continent = inputData[0];
                string country = inputData[1];
                string city = inputData[2];

                if (!continentsData.ContainsKey(continent))
                {
                    continentsData.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!continentsData[continent].ContainsKey(country))
                {
                    continentsData[continent][country] = new List<string>();
                }

                continentsData[continent][country].Add(city);                
            }

            foreach (KeyValuePair<string, Dictionary<string, List<string>>> continentCountries in continentsData)
            {
                string continent = continentCountries.Key;
                Console.WriteLine(continent + ":");
                foreach (KeyValuePair<string, List<string>> countryCities in continentCountries.Value)
                {
                    string country = countryCities.Key;
                    List<string> cities = countryCities.Value;
                    Console.WriteLine($"  {country} -> {string.Join(", ", cities)}");
                }                
            }
        }
    }
}
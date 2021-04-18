using System;
using System.Collections.Generic;
using System.IO;

namespace _01Singleton
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private static SingletonDataContainer instance = new SingletonDataContainer();

        private Dictionary<string, int> capitals = new Dictionary<string, int>();        

        private SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object...");

            string[] elements = File.ReadAllLines("Capitals.txt");
            for (int i = 0; i < elements.Length; i += 2)
            {
                this.capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        public static SingletonDataContainer Instance => instance;

        public int GetPopulation(string name)
        {
            return this.capitals[name];
        }
    }
}
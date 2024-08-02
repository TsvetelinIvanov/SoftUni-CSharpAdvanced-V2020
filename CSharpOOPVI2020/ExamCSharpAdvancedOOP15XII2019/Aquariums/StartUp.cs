using System;
using System.Collections.Generic;

namespace Aquariums
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium("Aquarium", 10);
            Console.WriteLine(aquarium.Report());
            
            List<string> list = new List<string>();
            Console.WriteLine("Fish available at {0}: {1}", aquarium.Name, string.Join(", ", list));
            Console.WriteLine("Fish available at {0}: {1}", aquarium.Name, null);
            
            Aquarium invalidAquarium = new Aquarium("", 10);
        }
    }
}

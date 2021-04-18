using System;

namespace _09DependencyInversion_HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWorld helloWorld = new HelloWorld();
            Console.WriteLine(helloWorld.Greeting("Pesho", DateTime.Now));
            Console.WriteLine(helloWorld.Greeting("Pesho", new DateTime(2020,7,19,8,10,18)));//Good morning, Pesho
            Console.WriteLine(helloWorld.Greeting("Pesho", new DateTime(2020,7,19,13,10,18)));//Good afternoon, Pesho
            Console.WriteLine(helloWorld.Greeting("Pesho", new DateTime(2020,7,19,18,10,18)));//Good evening, Pesho
        }
    }
}
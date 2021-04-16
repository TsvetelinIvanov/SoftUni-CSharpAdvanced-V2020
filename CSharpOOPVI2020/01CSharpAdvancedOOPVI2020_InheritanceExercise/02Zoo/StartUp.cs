using System;

namespace Zoo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal("Gonzo");
            Mammal mammal = new Mammal("Lary");
            Gorilla gorilla = new Gorilla("King Kong");
            Bear bear = new Bear("Bamze");
            Reptile reptile = new Reptile("Hishak");
            Lizard lizard = new Lizard("Momo");
            Snake snake = new Snake("Lara");

            Console.WriteLine(animal.Name);
            Console.WriteLine(mammal.Name);
            Console.WriteLine(gorilla.Name);
            Console.WriteLine(bear.Name);
            Console.WriteLine(reptile.Name);
            Console.WriteLine(lizard.Name);
            Console.WriteLine(snake.Name);            
        }
    }
}
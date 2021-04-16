using System;

namespace Restaurant
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Tea tea = new Tea("green", 3.1m, 100);
            Coffee coffee = new Coffee("black", 1.7);
            Soup soup = new Soup("chicken", 3.95m, 300);
            Fish fish = new Fish("salmon", 5.87m);
            Cake cake = new Cake("milk");            

            Console.WriteLine(tea.Milliliters);
            Console.WriteLine(coffee.Price + " " + coffee.Milliliters + " " + coffee.Caffeine);
            Console.WriteLine(soup.Price);
            Console.WriteLine(fish.Grams);
            Console.WriteLine(cake.Grams + " " + cake.Calories);            
        }
    }
}
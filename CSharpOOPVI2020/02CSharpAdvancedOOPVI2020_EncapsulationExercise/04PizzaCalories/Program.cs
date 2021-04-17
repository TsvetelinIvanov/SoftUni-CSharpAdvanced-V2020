using System;
using System.Linq;

namespace _04PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pizzaName = Console.ReadLine().Split().LastOrDefault();
                Pizza pizza = new Pizza(pizzaName);
                string input = string.Empty;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] ingredienthData = input.Split();
                    
                    if (ingredienthData[0] == "Dough")
                    {
                        string flourType = ingredienthData[1];
                        string bakingTechnique = ingredienthData[2];
                        double weight = double.Parse(ingredienthData[3]);

                        Dough dough = new Dough(flourType, bakingTechnique, weight);
                        //Console.WriteLine($"{dough.Calories:f2}");
                        pizza.Dough = dough;
                    }
                    else if (ingredienthData[0] == "Topping")
                    {
                        string toppingType = ingredienthData[1];
                        double weight = double.Parse(ingredienthData[2]);

                        Topping topping = new Topping(toppingType, weight);
                        //Console.WriteLine($"{topping.Calories:f2}");
                        pizza.AddTopping(topping);
                    }
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
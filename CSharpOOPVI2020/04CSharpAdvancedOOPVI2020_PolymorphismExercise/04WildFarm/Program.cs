using _04WildFarm.Animals;
using _04WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            int counter = 0;
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                if (counter % 2 == 0)
                {
                    Animal animal = CreateAnimal(input);                    
                    animals.Add(animal);
                }
                else
                {                    
                    Food food = CreateFood(input);
                    try
                    {
                        Animal animal = animals.LastOrDefault();
                        Console.WriteLine(animal.ProduceSound());
                        animal.Eat(food);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }

                counter++;
            }

            animals.ForEach(a => Console.WriteLine(a));
        }        

        private static Animal CreateAnimal(string input)
        {
            string[] animalData = input.Split();
            string type = animalData[0];
            string name = animalData[1];
            double weight = double.Parse(animalData[2]);
            switch (type)
            {
                case "Hen":
                    double henWingSize = double.Parse(animalData[3]);
                    
                    return new Hen(name, weight, henWingSize);
                case "Owl":
                    double owlWingSize = double.Parse(animalData[3]);
                    
                    return new Owl(name, weight, owlWingSize);
                case "Mouse":
                    string mouseLivingRegion = animalData[3];
                    
                    return new Mouse(name, weight, mouseLivingRegion);
                case "Dog":
                    string dogLivingRegion = animalData[3];
                    
                    return new Dog(name, weight, dogLivingRegion);
                case "Cat":
                    string catLivingRegion = animalData[3];
                    string catBreed = animalData[4];
                    
                    return new Cat(name, weight, catLivingRegion, catBreed);
                case "Tiger":
                    string tigerLivingRegion = animalData[3];
                    string tigerBreed = animalData[4];
                    
                    return new Tiger(name, weight, tigerLivingRegion, tigerBreed);
                default:
                    throw new ArgumentException("Invalid animal type!");
            }
        }

        private static Food CreateFood(string input)
        {
            string foodType = input.Split().FirstOrDefault();
            int foodQuantity = int.Parse(input.Split().LastOrDefault());
            switch (foodType)
            {
                case "Vegetable":
                    
                    return new Vegetable(foodQuantity);
                case "Fruit":
                    
                    return new Fruit(foodQuantity);
                case "Meat":
                    
                    return new Meat(foodQuantity);
                case "Seeds":
                    
                    return new Seeds(foodQuantity);
                default:
                    throw new ArgumentException("Invalid food type!");
            }
        }
    }
}

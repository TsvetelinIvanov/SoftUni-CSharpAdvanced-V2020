using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string[] animalData = Console.ReadLine().Split();
                    if (animalData.Length < 2)
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                    else if (animalData.Length < 3 && (input != "Tomcat" || input != "Kitten"))
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    string name = animalData[0];                   
                    
                    if (!int.TryParse(animalData[1], out int age))
                    {
                        throw new ArgumentException("Invalid input!");
                    }                    
                    
                    switch (input)
                    {
                        case "Dog":
                            Dog dog = new Dog(name, age, animalData[2]);
                            animals.Add(dog);
                            break;
                        case "Frog":
                            Frog frog = new Frog(name, age, animalData[2]);
                            animals.Add(frog);
                            break;
                        case "Cat":
                            Cat cat = new Cat(name, age, animalData[2]);
                            animals.Add(cat);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(name, age);
                            animals.Add(tomcat);
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(name, age);
                            animals.Add(kitten);
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal);
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
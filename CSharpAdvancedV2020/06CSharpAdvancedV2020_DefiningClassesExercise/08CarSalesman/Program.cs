using System;
using System.Collections.Generic;
using System.Linq;

namespace _08CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();
            int enginesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < enginesCount; i++)
            {
                string[] engineData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = engineData[0];
                int power = int.Parse(engineData[1]);
                if (engineData.Length == 2)
                {
                    Engine engine = new Engine(model, power);
                    engines.Add(engine);
                }
                else if(engineData.Length == 3)
                {
                    if (int.TryParse(engineData[2], out int displacement))
                    {
                        Engine engine = new Engine(model, power, displacement);
                        engines.Add(engine);
                    }
                    else
                    {
                        string efficiency = engineData[2];
                        Engine engine = new Engine(model, power, efficiency);
                        engines.Add(engine);
                    }
                }
                else if (engineData.Length == 4)
                {
                    int displacement = int.Parse(engineData[2]);
                    string efficiency = engineData[3];
                    Engine engine = new Engine(model, power, displacement, efficiency);
                    engines.Add(engine);
                }
            }

            int carsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsCount; i++)
            {
                string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carData[0];
                Engine engine = engines.FirstOrDefault(e => e.Model == carData[1]);
                if (carData.Length == 2)
                {
                    Car car = new Car(model, engine);
                    cars.Add(car);
                }
                else if (carData.Length == 3)
                {
                    if (int.TryParse(carData[2], out int weight))
                    {
                        Car car = new Car(model, engine, weight);
                        cars.Add(car);
                    }
                    else
                    {
                        string color = carData[2];
                        Car car = new Car(model, engine, color);
                        cars.Add(car);
                    }
                }
                else if (carData.Length == 4)
                {
                    int weight = int.Parse(carData[2]);
                    string color = carData[3];
                    Car car = new Car(model, engine, weight, color);
                    cars.Add(car);
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
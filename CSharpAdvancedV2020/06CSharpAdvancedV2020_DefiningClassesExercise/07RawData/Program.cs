using System;
using System.Collections.Generic;
using System.Linq;

namespace _07RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int carsNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsNumber; i++)
            {
                string[] carData = Console.ReadLine().Split();
                Car car = new Car(carData[0], carData[1], carData[2], carData[3], carData[4], carData[5], carData[6], carData[7], carData[8], carData[9], carData[10], carData[11], carData[12]);
                cars.Add(car);
            }

            string filter = Console.ReadLine();
            Func<Car, bool> fragileFilter = car =>
            {
                if (car.Cargo.Type == "fragile" && car.Tires.Any(t => t.Pressure < 1))
                {
                    return true;
                }

                return false;
            };

            Func<Car, bool> flamableFilter = car =>
            {
                if (car.Cargo.Type == "flamable" && car.Engine.Power > 250)
                {
                    return true;
                }

                return false;
            };

            if (filter == "fragile")
            {
                cars.Where(fragileFilter).ToList().ForEach(c => Console.WriteLine(c.Model));
            }
            else if (filter == "flamable")
            {
                cars.Where(flamableFilter).ToList().ForEach(c => Console.WriteLine(c.Model));
            }
        }
    }
}
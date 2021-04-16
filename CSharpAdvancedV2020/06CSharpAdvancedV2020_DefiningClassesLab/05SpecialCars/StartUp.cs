using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();

            string inputTires = string.Empty;
            while ((inputTires = Console.ReadLine()) != "No more tires")
            {
                string[] tiresInfo = inputTires.Split();
                Tire[] tiresSet = new Tire[tiresInfo.Length / 2];
                int tiresSetsCount = 0;
                for (int i = 0; i < tiresInfo.Length; i += 2)
                {
                    int year = int.Parse(tiresInfo[i]);
                    double pressure = double.Parse(tiresInfo[i + 1]);
                    tiresSet[tiresSetsCount] = new Tire(year, pressure);
                    tiresSetsCount++;
                }

                tires.Add(tiresSet);
            }

            string inputEngine = string.Empty;
            while ((inputEngine = Console.ReadLine()) != "Engines done")
            {
                int horsePower = int.Parse(inputEngine.Split().First());
                double cubicCapacity = double.Parse(inputEngine.Split().Last());
                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }

            string inputCar = string.Empty;
            while ((inputCar = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = inputCar.Split();
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);
            }

            Func<Car, bool> specialCarFilter = car =>
            {
                int year = car.Year;
                int horsePower = car.Engine.HorsePower;
                double pressureSum = car.Tires.Sum(t => t.Pressure);
                if (year >= 2017 && horsePower > 330 && pressureSum >= 9 && pressureSum <= 10)
                {
                    return true;
                }

                return false;
            };

            List<Car> specialCars = cars.Where(specialCarFilter).ToList();
            foreach (Car car in specialCars)
            {
                car.Drive(20);
            }

            foreach (Car car in specialCars)
            {
                StringBuilder carInfoBuilder = new StringBuilder();
                carInfoBuilder.AppendLine("Make: " + car.Make);
                carInfoBuilder.AppendLine("Model: " + car.Model);
                carInfoBuilder.AppendLine("Year: " + car.Year);
                carInfoBuilder.AppendLine("HorsePowers: " + car.Engine.HorsePower);
                carInfoBuilder.Append("FuelQuantity: " + car.FuelQuantity);

                Console.WriteLine(carInfoBuilder);
            }
        }
    }
}
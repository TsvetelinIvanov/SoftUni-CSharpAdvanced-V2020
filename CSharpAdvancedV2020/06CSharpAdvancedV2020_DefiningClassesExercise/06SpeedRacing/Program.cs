using System;
using System.Collections.Generic;
using System.Linq;

namespace _06SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int carsNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsNumber; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(carInfo[2]);
                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                cars.Add(car);
            }

            string carForDriving = string.Empty;
            while ((carForDriving = Console.ReadLine()) != "End")
            {
                string[] drivingInfo = carForDriving.Split();
                string model = drivingInfo[1];
                double distance = double.Parse(drivingInfo[2]);
                Car car = cars.FirstOrDefault(c => c.Model == model);
                car.Drive(distance);
            }

            cars.ForEach(c => Console.WriteLine($"{c.Model} {c.FuelAmount:f2} {c.TravelledDistance}"));
        }
    }
}
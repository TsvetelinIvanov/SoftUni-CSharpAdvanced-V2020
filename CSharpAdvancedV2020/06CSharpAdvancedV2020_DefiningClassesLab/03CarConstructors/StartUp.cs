using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelCapacity = double.Parse(Console.ReadLine());
            double fuelConsumpion = double.Parse(Console.ReadLine());

            Car car = new Car();
            Car otherCar = new Car(make, model, year);
            Car newCar = new Car(make, model, year, fuelCapacity, fuelConsumpion);
        }
    }
}
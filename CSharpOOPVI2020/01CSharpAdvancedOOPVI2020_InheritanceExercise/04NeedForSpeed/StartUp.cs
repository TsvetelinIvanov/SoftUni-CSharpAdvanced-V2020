using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CrossMotorcycle crossMotorcycle = new CrossMotorcycle(50, 20);
            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(100, 20);
            FamilyCar familyCar = new FamilyCar(120, 40);
            SportCar sportCar = new SportCar(300, 40);

            crossMotorcycle.Drive(3);
            raceMotorcycle.Drive(3);
            familyCar.Drive(3);
            sportCar.Drive(3);

            Console.WriteLine(crossMotorcycle.Fuel);
            Console.WriteLine(raceMotorcycle.Fuel);
            Console.WriteLine(familyCar.Fuel);
            Console.WriteLine(sportCar.Fuel);
        }
    }
}
using System;

namespace _11StructuralPatterns_Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Car compactCar = new CompactCar();
            compactCar = new Navigation(compactCar);
            compactCar = new Sunroof(compactCar);
            compactCar = new LeatherSeats(compactCar);

            Console.WriteLine(compactCar.GetDescription());//Compact Car, Navigation, Sunroof,  Leather Seats
            Console.WriteLine($"{compactCar.GetCarPrice():C2}");//20 000,00 лв.
        }
    }
}
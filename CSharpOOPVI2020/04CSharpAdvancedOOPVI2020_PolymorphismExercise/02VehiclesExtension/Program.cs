using System;
using System.Linq;

namespace _02VehiclesExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] carData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
            double[] truckData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
            double[] busData = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();

            Car car = new Car(carData[0], carData[1], carData[2]);
            Truck truck = new Truck(truckData[0], truckData[1], truckData[2]);
            Bus bus = new Bus(busData[0], busData[1], busData[2]);

            int commandsNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsNumber; i++)
            {
                string[] commandLine = Console.ReadLine().Split();
                string command = commandLine[0];
                string vehicle = commandLine[1];
                switch (command)
                {
                    case "Drive":
                        double distance = double.Parse(commandLine[2]);
                        switch (vehicle)
                        {
                            case "Car":
                                Console.WriteLine(car.Drive(distance));
                                break;
                            case "Truck":
                                Console.WriteLine(truck.Drive(distance));
                                break;
                            case "Bus":
                                Console.WriteLine(bus.Drive(distance));
                                break;
                        }

                        break;
                    case "DriveEmpty":
                        double emptyBusDistance = double.Parse(commandLine[2]);
                        bus.IsEmpty = true;                        
                        Console.WriteLine(bus.Drive(emptyBusDistance));
                        bus.IsEmpty = false;
                        break;
                    case "Refuel":
                        try
                        {
                            double fuel = double.Parse(commandLine[2]);
                            switch (vehicle)
                            {
                                case "Car":
                                    car.Refuel(fuel);
                                    break;
                                case "Truck":
                                    truck.Refuel(fuel);
                                    break;
                                case "Bus":
                                    bus.Refuel(fuel);
                                    break;
                            }
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }                        

                        break;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
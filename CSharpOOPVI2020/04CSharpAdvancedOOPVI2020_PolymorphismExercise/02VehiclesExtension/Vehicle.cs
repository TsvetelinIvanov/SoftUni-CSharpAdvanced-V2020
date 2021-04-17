using System;

namespace _02VehiclesExtension
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            //if (fuelQuantity <= 0)
            //{
            //    throw new ArgumentException("Fuel must be a postive number");
            //}

            this.TankCapcity = tankCapacity;
            if (fuelQuantity > this.TankCapcity)
            {
                //Console.WriteLine($"Cannot fit {fuelQuantity} fuel in the tank");
                fuelQuantity = 0;                
            }

            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        protected double TankCapcity { get; private set; }

        public double FuelQuantity { get; set; }

        protected double FuelConsumption { get; private set; }

        public virtual double RealFuelConsumption => this.FuelConsumption;

        public string Drive(double distance)
        {
            if (this.RealFuelConsumption * distance > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= this.RealFuelConsumption * distance;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + fuel > this.TankCapcity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            this.FuelQuantity += fuel;
        }
    }
}
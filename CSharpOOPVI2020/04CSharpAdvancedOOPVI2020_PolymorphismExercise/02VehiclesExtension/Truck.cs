using System;

namespace _02VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double AirConditionerConsumpion = 1.6;
        private const double KeepedFuelPercent = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override double RealFuelConsumption => base.RealFuelConsumption + AirConditionerConsumpion;

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + fuel /* * KeepedFuelPercent */ > this.TankCapcity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            this.FuelQuantity += fuel * KeepedFuelPercent;
        }
    }
}
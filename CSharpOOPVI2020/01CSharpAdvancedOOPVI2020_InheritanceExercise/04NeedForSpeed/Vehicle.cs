﻿namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            this.DefaultFuelConsumption = 1.25;
            this.FuelConsumption = this.DefaultFuelConsumption;
        }

        public double DefaultFuelConsumption { get; set; }

        public virtual double FuelConsumption { get; set; }

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            if (this.Fuel < this.FuelConsumption * kilometers)
            {
                return;
            }

            this.Fuel -= this.FuelConsumption * kilometers;
        }
    }
}

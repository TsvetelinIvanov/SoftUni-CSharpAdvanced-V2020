﻿namespace _01Vehicles
{
    public class Car : Vehicle
    {
        private const double AirConditionerConsumpion = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {

        }

        public override double RealFuelConsumption => base.RealFuelConsumption + AirConditionerConsumpion;
    }
}
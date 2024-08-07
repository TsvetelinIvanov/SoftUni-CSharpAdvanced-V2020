﻿namespace _11StructuralPatterns_Decorator
{
    public class CompactCar : Car
    {
        public CompactCar()
        {
            this.Description = "Compact Car";
        }

        public override double GetCarPrice() => 10000.00;

        public override string GetDescription() => this.Description;
    }
}
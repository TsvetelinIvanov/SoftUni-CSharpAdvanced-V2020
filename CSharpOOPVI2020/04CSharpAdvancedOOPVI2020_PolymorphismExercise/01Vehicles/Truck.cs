namespace _01Vehicles
{
    public class Truck : Vehicle
    {
        private const double AirConditionerConsumpion = 1.6;
        private const double KeepedFuelPercent = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {

        }

        public override double RealFuelConsumption => base.RealFuelConsumption + AirConditionerConsumpion;

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * KeepedFuelPercent);
        }
    }
}
namespace _02VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double AirConditionerConsumpion = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override double RealFuelConsumption => base.RealFuelConsumption + AirConditionerConsumpion;
    }
}
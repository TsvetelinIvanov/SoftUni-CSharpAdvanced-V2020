namespace _01Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }

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
            this.FuelQuantity += fuel;
        }
    }
}
namespace _02VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double AirConditionerConsumpion = 1.4;        

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.IsEmpty = false;
        }

        public bool IsEmpty { get; set; }

        public override double RealFuelConsumption 
        {
            get 
            {                
                double realFuelConsumption = base.RealFuelConsumption + AirConditionerConsumpion;
                if (this.IsEmpty)
                {
                    realFuelConsumption = base.RealFuelConsumption;                    
                }

                return realFuelConsumption;
            }
        }
    }
}
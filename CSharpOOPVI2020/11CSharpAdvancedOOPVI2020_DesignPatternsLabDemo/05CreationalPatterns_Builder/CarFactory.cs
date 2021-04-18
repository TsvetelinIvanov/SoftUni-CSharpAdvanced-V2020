namespace _05CreationalPatterns_Builder
{
    public class CarFactory
    {
        public Car Build(CarBuilder builder)
        {
            builder.SetHorsePower();

            builder.SetTopSpeed();

            builder.SetImpressiveFeature();

            return builder.GetCar();
        }
    }
}
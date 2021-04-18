namespace _11StructuralPatterns_Decorator
{
    public class CarDecorator : Car
    {
        protected Car car;

        public CarDecorator(Car car)
        {
            this.car = car;
        }

        public override double GetCarPrice() => this.car.GetCarPrice();

        public override string GetDescription() => this.car.GetDescription();
    }
}
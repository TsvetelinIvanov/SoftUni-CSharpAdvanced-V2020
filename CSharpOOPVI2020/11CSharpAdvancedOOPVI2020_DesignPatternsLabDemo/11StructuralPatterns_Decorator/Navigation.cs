namespace _11StructuralPatterns_Decorator
{
    public class Navigation : CarDecorator
    {
        public Navigation(Car car) : base(car)
        {
            this.Description = "Navigation";
        }

        public override string GetDescription() => $"{this.car.GetDescription()}, {this.Description}";

        public override double GetCarPrice() => this.car.GetCarPrice() + 5000;
    }
}
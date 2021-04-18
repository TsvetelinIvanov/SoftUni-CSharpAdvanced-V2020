namespace _11StructuralPatterns_Decorator
{
    public class Sunroof : CarDecorator
    {
        public Sunroof(Car car) : base(car)
        {
            this.Description = "Sunroof";
        }

        public override string GetDescription() => $"{this.car.GetDescription()}, {this.Description}";

        public override double GetCarPrice() => this.car.GetCarPrice() + 2500;
    }
}
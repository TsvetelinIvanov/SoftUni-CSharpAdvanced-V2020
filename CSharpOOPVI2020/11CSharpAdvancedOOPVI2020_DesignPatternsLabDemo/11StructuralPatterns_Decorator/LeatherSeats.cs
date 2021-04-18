namespace _11StructuralPatterns_Decorator
{
    public class LeatherSeats : CarDecorator
    {
        public LeatherSeats(Car car) : base(car)
        {
            this.Description = "Leather Seats";
        }

        public override string GetDescription() => $"{this.car.GetDescription()},  {this.Description}";

        public override double GetCarPrice() => this.car.GetCarPrice() + 2500;
    }
}
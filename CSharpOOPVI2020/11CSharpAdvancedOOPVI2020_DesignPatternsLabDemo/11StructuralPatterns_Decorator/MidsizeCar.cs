namespace _11StructuralPatterns_Decorator
{
    public class MidsizeCar : Car
    {
        public MidsizeCar()
        {
            this.Description = "Midsize Car";
        }

        public override double GetCarPrice() => 20000.00;

        public override string GetDescription() => this.Description;
    }
}
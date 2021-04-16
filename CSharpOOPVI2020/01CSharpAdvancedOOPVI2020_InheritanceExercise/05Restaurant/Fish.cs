namespace Restaurant
{
    public class Fish : MainDish
    {
        public const double RequiredGrams = 22;

        public Fish(string name, decimal price) : base(name, price, RequiredGrams)
        {

        }
    }
}
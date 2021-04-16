namespace Restaurant
{
    public class Cake : Dessert
    {
        public const decimal RequiredPrice = 5;
        public const double RequiredGrams = 250;
        public const double RecuiredCalories = 1000;

        public Cake(string name) : base(name, RequiredPrice, RequiredGrams, RecuiredCalories)
        {

        }
    }
}
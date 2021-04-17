namespace _04WildFarm.Animals
{
    public class Cat : Feline
    {
        private const string PronouncedSound = "Meow";
        private const double WeightIncreasingPercent = 0.3;
        private readonly string[] PossibleEatenFoods = new string[] { "Vegetable", "Meat" };

        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
            
        }

        public override string ProducedSound => PronouncedSound;

        public override double WeightIncreasingRate => WeightIncreasingPercent;

        public override string[] EatenFoods => PossibleEatenFoods;
    }
}
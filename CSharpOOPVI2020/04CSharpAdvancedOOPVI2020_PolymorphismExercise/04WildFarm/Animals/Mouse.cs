namespace _04WildFarm.Animals
{
    public class Mouse : Mammal
    {
        private const string PronouncedSound = "Squeak";
        private const double WeightIncreasingPercent = 0.1;
        private readonly string[] PossibleEatenFoods = new string[] { "Vegetable", "Fruit" };

        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {

        }

        public override string ProducedSound => PronouncedSound;

        public override double WeightIncreasingRate => WeightIncreasingPercent;

        public override string[] EatenFoods => PossibleEatenFoods;
    }
}
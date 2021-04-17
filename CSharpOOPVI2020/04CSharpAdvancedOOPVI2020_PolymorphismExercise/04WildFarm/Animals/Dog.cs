namespace _04WildFarm.Animals
{
    public class Dog : Mammal
    {
        private const string PronouncedSound = "Woof!";
        private const double WeightIncreasingPercent = 0.4;
        private readonly string[] PossibleEatenFoods = new string[] { "Meat" };

        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {

        }

        public override string ProducedSound => PronouncedSound;

        public override double WeightIncreasingRate => WeightIncreasingPercent;

        public override string[] EatenFoods => PossibleEatenFoods;
    }
}
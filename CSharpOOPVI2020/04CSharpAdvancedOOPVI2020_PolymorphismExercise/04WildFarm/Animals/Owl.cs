namespace _04WildFarm.Animals
{
    public class Owl : Bird
    {
        private const string PronouncedSound = "Hoot Hoot";
        private double WeightIncreasingPercent = 0.25;
        private readonly string[] PossibleEatenFoods = new string[] { "Meat" };

        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {

        }

        public override string ProducedSound => PronouncedSound;

        public override double WeightIncreasingRate => WeightIncreasingPercent;

        public override string[] EatenFoods => PossibleEatenFoods;
    }
}
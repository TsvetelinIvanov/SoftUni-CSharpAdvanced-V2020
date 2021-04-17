namespace _04WildFarm.Animals
{
    public class Hen : Bird
    {
        private const string PronouncedSound = "Cluck";
        private double WeightIncreasingPercent = 0.35;       

        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {

        }

        public override string ProducedSound => PronouncedSound;

        public override double WeightIncreasingRate => WeightIncreasingPercent;             
    }
}
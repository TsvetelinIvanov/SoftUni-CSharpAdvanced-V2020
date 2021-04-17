namespace _04WildFarm.Animals
{
    public class Tiger : Feline
    {
        private const string PronouncedSound = "ROAR!!!";        
        private readonly string[] PossibleEatenFoods = new string[] { "Meat" };

        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {

        }

        public override string ProducedSound => PronouncedSound;        

        public override string[] EatenFoods => PossibleEatenFoods;
    }
}

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int StartEnergy = 50;
        private const int EnergyDecresingNumber = 15;

        public SleepyBunny(string name) : base(name, StartEnergy)
        {

        }

        public override void Work()
        {
            this.Energy -= EnergyDecresingNumber;
        }
    }
}
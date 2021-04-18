namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        private const int StartEnergy = 50;
        private const int EnergyDecresingNumber = 15;

        public SleepyDwarf(string name) : base(name, StartEnergy)
        {

        }

        public override void Work()
        {
            this.Energy -= EnergyDecresingNumber;
        }
    }
}
namespace SantaWorkshop.Models.Dwarfs
{
    public class HappyDwarf : Dwarf
    {
        private const int StartEnergy = 100;

        public HappyDwarf(string name) : base(name, StartEnergy)
        {

        }        
    }
}
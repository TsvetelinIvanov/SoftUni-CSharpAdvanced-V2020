namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int StartEnergy = 100;

        public HappyBunny(string name) : base(name, StartEnergy)
        {

        }
    }
}
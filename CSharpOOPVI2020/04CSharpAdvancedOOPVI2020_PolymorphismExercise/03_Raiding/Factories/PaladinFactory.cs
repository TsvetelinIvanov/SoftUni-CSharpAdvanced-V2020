using _03_Raiding.Products;

namespace _03_Raiding.Factories
{
    public class PaladinFactory : HeroFactory
    {
        private string name;

        public PaladinFactory(string name)
        {
            this.name = name;
        }

        public override BaseHero GetHero()
        {
            return new Paladin(this.name);
        }
    }
}
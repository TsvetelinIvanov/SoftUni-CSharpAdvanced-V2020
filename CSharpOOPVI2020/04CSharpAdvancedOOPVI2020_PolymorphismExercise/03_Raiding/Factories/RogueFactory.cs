using _03_Raiding.Products;

namespace _03_Raiding.Factories
{
    public class RogueFactory : HeroFactory
    {
        private string name;

        public RogueFactory(string name)
        {
            this.name = name;
        }

        public override BaseHero GetHero()
        {
            return new Rogue(this.name);
        }
    }
}
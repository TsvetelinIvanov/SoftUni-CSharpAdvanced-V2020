using _03_Raiding.Products;

namespace _03_Raiding.Factories
{
    public class WarriorFactory : HeroFactory
    {
        private string name;

        public WarriorFactory(string name)
        {
            this.name = name;
        }

        public override BaseHero GetHero()
        {
            return new Warrior(this.name);
        }
    }
}
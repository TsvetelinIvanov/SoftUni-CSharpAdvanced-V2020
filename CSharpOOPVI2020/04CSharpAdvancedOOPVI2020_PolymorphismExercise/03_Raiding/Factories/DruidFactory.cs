using _03_Raiding.Products;

namespace _03_Raiding.Factories
{
    public class DruidFactory : HeroFactory
    {
        private string name;        

        public DruidFactory(string name)
        {
            this.name = name;            
        }

        public override BaseHero GetHero()
        {
            return new Druid(this.name);
        }
    }
}
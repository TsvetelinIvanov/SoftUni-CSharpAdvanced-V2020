namespace _03_Raiding.Products
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) : base(name, 100)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
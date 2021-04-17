namespace _03Raiding
{
    public abstract class BaseHeroHealer : BaseHero
    {
        protected BaseHeroHealer(string name, int power) : base(name, power)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
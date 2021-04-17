namespace _03Raiding
{
    public abstract class BaseHeroHitter : BaseHero
    {
        protected BaseHeroHitter(string name, int power) : base(name, power)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
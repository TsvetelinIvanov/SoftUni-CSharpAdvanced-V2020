﻿namespace _03_Raiding.Products
{
    public class Druid : BaseHero
    {        public Druid(string name) : base(name, 80)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
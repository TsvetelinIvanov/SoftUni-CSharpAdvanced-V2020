using System;
using System.Collections.Generic;
using System.Linq;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;
        
        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count => this.data.Count;

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            this.data.RemoveAll(h => h.Name == name);
        }

        public Hero GetHeroWithHighestStrength()
        {
            return this.data.OrderByDescending(h => h.Item.Strength).First();
        }

        public Hero GetHeroWithHighestAbility()
        {
            return this.data.OrderByDescending(h => h.Item.Ability).First();
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            return this.data.OrderByDescending(h => h.Item.Intelligence).First();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.data.Select(h => h.ToString()));
        }
    }
}
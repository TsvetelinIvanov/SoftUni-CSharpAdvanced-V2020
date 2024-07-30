using System;
using System.Collections.Generic;
using System.Linq;
using _03_Raiding.Products;
using _03_Raiding.Factories;

namespace _03_Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int heroesCount = int.Parse(Console.ReadLine());
            while (heroes.Count < heroesCount)
            {
                try
                {
                    string name = Console.ReadLine();
                    string type = Console.ReadLine();
                    HeroFactory heroFactory = CreateHeroFactory(type, name);
                    BaseHero hero = heroFactory.GetHero();
                    heroes.Add(hero);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int raidingGroupPower = heroes.Sum(h => h.Power);
            string raidingResult = "Victory!";
            if (bossPower > raidingGroupPower)
            {
                raidingResult = "Defeat...";
            }

            foreach (BaseHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            Console.WriteLine(raidingResult);
        }

        private static HeroFactory CreateHeroFactory(string type, string name)
        {
            switch (type)
            {
                case "Druid":
                    DruidFactory druid = new DruidFactory(name);
                    
                    return druid;
                case "Paladin":
                    PaladinFactory paladin = new PaladinFactory(name);
                    
                    return paladin;
                case "Rogue":
                    RogueFactory rogue = new RogueFactory(name);
                    
                    return rogue;
                case "Warrior":
                    WarriorFactory warrior = new WarriorFactory(name);
                    
                    return warrior;
                default:
                    throw new ArgumentException("Invalid hero!");
            }
        }
    }
}

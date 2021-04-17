using System;
using System.Collections.Generic;
using System.Linq;

namespace _03Raiding
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
                    BaseHero hero = CreateHero(type, name);
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

        private static BaseHero CreateHero(string type, string name)
        {
            switch (type)
            {
                case "Druid":
                    Druid druid = new Druid(name);
                    return druid;
                case "Paladin":
                    Paladin paladin = new Paladin(name);
                    return paladin;
                case "Rogue":
                    Rogue rogue = new Rogue(name);
                    return rogue;
                case "Warrior":
                    Warrior warrior = new Warrior(name);
                    return warrior;
                default:
                    throw new ArgumentException("Invalid hero!");
            }
        }
    }
}
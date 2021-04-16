using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero("Master", 1);
            Elf elf = new Elf("Oak", 2);
            MuseElf museElf = new MuseElf("Willow", 3);
            Wizard wizard = new Wizard("White", 2);
            DarkWizard darkWizard = new DarkWizard("Black", 3);
            SoulMaster soulMaster = new SoulMaster("Nebula", 4);
            Knight knight = new Knight("Rider", 2);
            DarkKnight darkKnight = new DarkKnight("DarkRider", 3);
            BladeKnight bladeKnight = new BladeKnight("BladeRider", 4);

            Console.WriteLine(hero);
            Console.WriteLine(elf);
            Console.WriteLine(museElf);
            Console.WriteLine(wizard);
            Console.WriteLine(darkWizard);
            Console.WriteLine(soulMaster);
            Console.WriteLine(knight);
            Console.WriteLine(darkKnight);
            Console.WriteLine(bladeKnight);
        }
    }
}
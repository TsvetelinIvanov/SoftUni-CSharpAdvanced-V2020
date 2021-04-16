using System;

namespace Heroes
{
    public class Item
    {
        public Item(int strength, int ability, int intelligence)
        {
            this.Strength = strength;
            this.Ability = ability;
            this.Intelligence = intelligence;
        }

        public int Strength { get; private set; }

        public int Ability { get; private set; }

        public int Intelligence { get; private set; }

        public override string ToString()
        {
            return "Item:" + Environment.NewLine + "  * Strength: " + this.Strength + Environment.NewLine + "  * Ability: " + this.Ability + Environment.NewLine + "  * Intelligence: " + this.Intelligence;
        }
    }
}
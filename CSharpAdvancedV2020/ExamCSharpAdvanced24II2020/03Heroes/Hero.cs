using System;

namespace Heroes
{
    public class Hero
    {
        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public string Name { get; private set; }

        public int Level { get; private set; }

        public Item Item { get; private set; }

        public override string ToString()
        {
            return $"Hero: {this.Name} - {this.Level}lvl" + Environment.NewLine + this.Item.ToString();
        }
    }
}
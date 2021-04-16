using System.Collections.Generic;

namespace _09PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int badgesNumber;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.Name = name;
            this.BadgesNumber = 0;
            this.Pokemons = new List<Pokemon>();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int BadgesNumber
        {
            get { return this.badgesNumber; }
            set { this.badgesNumber = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
            set { this.pokemons = value; }
        }
    }
}
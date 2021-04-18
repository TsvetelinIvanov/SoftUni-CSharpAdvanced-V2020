using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name 
        { 
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; }

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public int Comfort => this.decorations.Sum(d => d.Comfort);

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count >= this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }        

        public void Feed()
        {
            foreach (IFish fish in this.Fish)
            {
                fish.Eat();
            }            
        }

        public string GetInfo()
        {
            string fish = "none";
            if (this.Fish.Count > 0)
            {
                fish = string.Join(", ", this.Fish.Select(f => f.Name));
            }

            return $"{this.Name} ({this.GetType().Name}):{Environment.NewLine}Fish: {fish}{Environment.NewLine}Decorations: {this.Decorations.Count}{Environment.NewLine}Comfort: {this.Comfort}";
        }        
    }
}
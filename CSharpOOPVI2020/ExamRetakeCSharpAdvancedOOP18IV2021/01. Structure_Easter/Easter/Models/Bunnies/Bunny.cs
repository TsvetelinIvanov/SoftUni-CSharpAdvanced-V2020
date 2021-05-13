using System;
using System.Collections.Generic;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private const int EnergyDecresingNumber = 10;

        private string name;
        private int energy;        
        private ICollection<IDye> dyes;

        protected Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;            
            this.dyes = new List<IDye>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }

                this.name = value;
            }
        }

        public int Energy
        {
            get { return this.energy; }
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.energy = value;
            }
        }
        
        public ICollection<IDye> Dyes => this.dyes;

        public void AddDye(IDye dye)
        {            
            this.dyes.Add(dye);
        }

        public virtual void Work()
        {
            this.Energy -= EnergyDecresingNumber;
        }

        public override string ToString()
        {
            return $"Name: {this.Name}{Environment.NewLine}Energy: {this.Energy}{Environment.NewLine}Dyes: {this.Dyes.Count} not finished";
        }
    }
}
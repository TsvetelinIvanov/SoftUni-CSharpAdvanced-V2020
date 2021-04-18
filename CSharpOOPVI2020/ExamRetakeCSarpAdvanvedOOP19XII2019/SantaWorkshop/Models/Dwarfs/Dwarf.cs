using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SantaWorkshop.Models.Dwarfs
{
    public abstract class Dwarf : IDwarf
    {
        private const int EnergyDecresingNumber = 10;

        private string name;
        private int energy;
        // For Judge it must be with private field:
        private List<IInstrument> instruments;

        protected Dwarf(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            // For Judge it must be with private field:
            //this.Instruments = new List<IInstrument>();
            this.instruments = new List<IInstrument>();
        }

        public string Name 
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
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

        // For Judge it must be with private field:
        //public ICollection<IInstrument> Instruments { get; private set; }
        public ICollection<IInstrument> Instruments => this.instruments;

        public void AddInstrument(IInstrument instrument)
        {
            //this.Instruments.Add(instrument);
            this.instruments.Add(instrument);
        }
        
        public virtual void Work()
        {
            this.Energy -= EnergyDecresingNumber;
        }        

        public override string ToString()
        {
            return $"Name: {this.Name}{Environment.NewLine}Energy: {this.Energy}{Environment.NewLine}Instruments: {this.Instruments.Where(i => !i.IsBroken()).Count()} not broken left";
        }
    }
}
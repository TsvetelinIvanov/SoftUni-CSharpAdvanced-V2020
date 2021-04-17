using System;
using _07MilitaryElite.Interfaces;

namespace _07MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get { return this.corps; }
            set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException("Invalid corps!");
                }

                this.corps = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + "Corps: " + this.Corps + Environment.NewLine;
        }
    }
}
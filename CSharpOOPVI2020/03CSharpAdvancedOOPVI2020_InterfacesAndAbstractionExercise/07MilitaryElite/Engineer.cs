using System;
using System.Collections.Generic;
using System.Text;
using _07MilitaryElite.Interfaces;

namespace _07MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<IRepair>();
        }

        public List<IRepair> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder repairBuilder = new StringBuilder(Environment.NewLine);
            foreach (Repair repair in this.Repairs)
            {
                repairBuilder.AppendLine("  " + repair.ToString());
            }

            string repairsData = repairBuilder.ToString().TrimEnd();
            if (this.Repairs.Count == 0)
            {
                repairsData = string.Empty;
            }

            return base.ToString() + "Repairs:" + repairsData;
        }        
    }
}
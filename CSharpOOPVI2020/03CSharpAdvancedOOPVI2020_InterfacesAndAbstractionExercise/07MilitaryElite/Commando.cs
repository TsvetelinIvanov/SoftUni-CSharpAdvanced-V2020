using System;
using System.Collections.Generic;
using System.Text;
using _07MilitaryElite.Interfaces;

namespace _07MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<IMission>();
        }

        public List<IMission> Missions { get; private set; }

        public override string ToString()
        {
            StringBuilder missionBuilder = new StringBuilder(Environment.NewLine);
            foreach (Mission mission in this.Missions)
            {
                missionBuilder.AppendLine("  " + mission.ToString());
            }

            string missionsData = missionBuilder.ToString().TrimEnd();
            if (this.Missions.Count == 0)
            {
                missionsData = string.Empty;
            }

            return base.ToString() + "Missions:" + missionsData;
        }        
    }
}
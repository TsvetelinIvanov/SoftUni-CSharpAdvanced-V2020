using System;
using System.Collections.Generic;
using System.Text;
using _07MilitaryElite.Interfaces;

namespace _07MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public List<IPrivate> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder privateBuilder = new StringBuilder();
            foreach (Private @private in this.Privates)
            {
                privateBuilder.AppendLine("  " + @private.ToString());
            }

            string privatesData = Environment.NewLine + privateBuilder.ToString().TrimEnd();
            if (this.Privates.Count == 0)
            {
                privatesData = string.Empty;
            }

            return base.ToString() + Environment.NewLine + "Privates:" + privatesData;
        }        
    }
}
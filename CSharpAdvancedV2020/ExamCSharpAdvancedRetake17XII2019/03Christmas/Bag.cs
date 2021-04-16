using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;

        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.data = new List<Present>();
        }

        public string Color { get; private set; }

        public int Capacity { get; private set; }

        public int Count => this.data.Count;

        public void Add(Present present)
        {
            if (this.Capacity > this.Count)
            {
                this.data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            Present present = this.data.FirstOrDefault(p => p.Name == name);
            if (present == null)
            {
                return false;
            }

            this.data.Remove(present);

            return true;
        }

        public Present GetHeaviestPresent()
        {
            //double maxPresentWeight = this.data.Max(p => p.Weight);
            //Present present = this.data.SingleOrDefault(p => p.Weight == maxPresentWeight);
            Present present = this.data.OrderByDescending(p => p.Weight).FirstOrDefault();

            return present;
        }

        public Present GetPresent(string name)
        {
            Present present = this.data.FirstOrDefault(p => p.Name == name);

            return present;
        }

        public string Report()
        {
            StringBuilder reportBuilder = new StringBuilder(this.Color + " bag contains:" + Environment.NewLine);
            foreach (Present present in this.data)
            {
                reportBuilder.AppendLine(present.ToString().Trim());
            }

            return reportBuilder.ToString().Trim();
        }
    }
}
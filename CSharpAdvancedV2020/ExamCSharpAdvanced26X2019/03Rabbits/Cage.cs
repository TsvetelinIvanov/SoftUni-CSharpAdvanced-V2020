using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Rabbit>(capacity);
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Count => this.data.Count;

        public void Add(Rabbit rabbit)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            Rabbit rabbit = this.data.FirstOrDefault(r => r.Name == name);
            if (rabbit == null)
            {
                return false;
            }

            this.data.Remove(rabbit);

            return true;
        }

        public void RemoveSpecies(string species)
        {            
            this.data.RemoveAll(r => r.Species == species);            
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbit = this.data.FirstOrDefault(r => r.Name == name);
            rabbit.Available = false;

            return rabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            this.data.Where(r => r.Species == species).ToList().ForEach(r => r.Available = false);

            return this.data.Where(r => r.Species == species).ToArray();
        }

        public string Report()
        {
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine($"Rabbits available at {this.Name}:");
            foreach (Rabbit rabbit in this.data.Where(r => r.Available == true))
            {
                reportBuilder.AppendLine(rabbit.ToString());
            }

            return reportBuilder.ToString().Trim();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }

        public string Type { get; private set; }

        public int Capacity { get; private set; }

        public int Count => this.data.Count;

        public void Add(Car car)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car car = this.data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            if (car == null)
            {
                return false;
            }

            this.data.Remove(car);

            return true;
        }

        public Car GetLatestCar()
        {
            //if (!this.data.Any())
            //{
            //    return null;
            //}

            Car car = this.data.OrderByDescending(c => c.Year).FirstOrDefault();

            return car;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car car = this.data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            return car;
        }

        public string GetStatistics()
        {
            StringBuilder statisticsBuilder = new StringBuilder($"The cars are parked in {this.Type}:" + Environment.NewLine + string.Join(Environment.NewLine, this.data.Select(c => c.ToString())));

            return statisticsBuilder.ToString();
        }
    }
}

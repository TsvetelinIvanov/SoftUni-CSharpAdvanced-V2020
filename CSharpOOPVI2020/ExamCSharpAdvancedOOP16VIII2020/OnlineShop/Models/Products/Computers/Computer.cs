using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance
        {
            get
            {
                if (this.Components.Count > 0)
                {
                    return base.OverallPerformance + this.Components.Average(c => c.OverallPerformance);
                }

                return base.OverallPerformance;
            }
        }

        public override decimal Price
        {
            get
            {
                decimal totalPrice = base.Price;

                if (this.Components.Count > 0)
                {
                    totalPrice += this.Components.Sum(c => c.Price);
                }

                if (this.Peripherals.Count > 0)
                {
                    totalPrice += this.Peripherals.Sum(p => p.Price);
                }

                return totalPrice;
            }
        }

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public void AddComponent(IComponent component)
        {
            if (this.Components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = this.Components.FirstOrDefault(c => c.GetType().Name == componentType);
            if (component == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NonExistentComponent, componentType, this.GetType().Name, this.Id));
            }

            this.components.Remove(component);

            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id)); ;
            }

            this.peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheral = this.Peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);
            if (peripheral == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NonExistentPeripheral, peripheralType, this.GetType().Name, this.Id)); ;
            }

            this.peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder computerBuilder = new StringBuilder();
            computerBuilder.AppendLine(base.ToString());
            computerBuilder.AppendLine($" Components ({this.Components.Count}):");
            foreach (IComponent component in this.Components)
            {
                computerBuilder.AppendLine("  " + component.ToString());
            }

            double averageOveralPerformance = this.Peripherals.Count == 0 ? 0 : this.Peripherals.Average(p => p.OverallPerformance);
            computerBuilder.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({averageOveralPerformance:f2}):");
            foreach (IPeripheral peripheral in this.Peripherals)
            {
                computerBuilder.AppendLine("  " + peripheral.ToString());
            }

            return computerBuilder.ToString().TrimEnd();
        }
    }
}

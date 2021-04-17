using System;
using System.Collections.Generic;
using System.Linq;

namespace _04PizzaCalories
{
    public class Pizza
    {
        private const int MinNameLength = 1;
        private const int MaxNameLength = 15;
        private const int MinToppingsNumber = 0;
        private const int MaxToppingsNumber = 10;

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinNameLength || value.Length > MaxNameLength)
                {
                    throw new ArgumentException($"Pizza name should be between {MinNameLength} and {MaxNameLength} symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough
        {
            get { return this.dough; }
            set
            {
                this.dough = value;
            }
        }

        public int NumberOfToppings => this.toppings.Count;

        public double TotalCalories => this.Dough.Calories + this.toppings.Sum(t => t.Calories);
        
        public void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);
            if (this.NumberOfToppings > MaxToppingsNumber)
            {
                throw new ArgumentException($"Number of toppings should be in range [{MinToppingsNumber}..{MaxToppingsNumber}].");
            }
        }
    }
}
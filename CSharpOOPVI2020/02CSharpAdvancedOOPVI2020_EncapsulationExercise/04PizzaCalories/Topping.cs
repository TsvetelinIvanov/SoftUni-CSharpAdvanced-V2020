using System;
using System.Collections.Generic;

namespace _04PizzaCalories
{
    public class Topping
    {
        private const double MinWeight = 1;
        private const double MaxWeight = 50;
        private const double BaseCaloriesPerGram = 2;
        private readonly Dictionary<string, double> toppingTypeModifiers = new Dictionary<string, double>()
        {
            {"meat", 1.2 },
            {"veggies", 0.8 },
            {"cheese", 1.1 },
            {"sauce", 0.9 }
        };

        private double weight;
        private string type;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [{MinWeight}..{MaxWeight}].");
                }

                this.weight = value;
            }
        }

        public string Type
        {
            get { return this.type; }
            set
            {
                if (!toppingTypeModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        public double Calories => BaseCaloriesPerGram * this.Weight * toppingTypeModifiers[this.Type.ToLower()];
    }
}
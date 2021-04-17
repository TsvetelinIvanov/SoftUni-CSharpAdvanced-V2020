using System;
using System.Collections.Generic;

namespace _04PizzaCalories
{    
    public class Dough
    {        
        private const double MinWeight = 1;
        private const double MaxWeight = 200;
        private const double BaseCaloriesPerGram = 2;
        private readonly Dictionary<string, double> flourTypeModifiers = new Dictionary<string, double>()
        {
            {"white", 1.5 },
            {"wholegrain", 1.0 }
        };

        private readonly Dictionary<string, double> bakingTechniqueModifiers = new Dictionary<string, double>()
        {
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1.0 }
        };

        private double weight;
        private string flourType;
        private string bakingTechnique;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechique = bakingTechnique;
            this.Weight = weight;
        }

        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
                }

                this.weight = value;
            }
        }

        public string FlourType
        {
            get { return this.flourType; }
            set
            {
                if (!flourTypeModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechique
        {
            get { return this.bakingTechnique; }
            set
            {
                if (!bakingTechniqueModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public double Calories => BaseCaloriesPerGram * this.Weight * flourTypeModifiers[this.FlourType.ToLower()] * bakingTechniqueModifiers[this.BakingTechique.ToLower()];
    }
}
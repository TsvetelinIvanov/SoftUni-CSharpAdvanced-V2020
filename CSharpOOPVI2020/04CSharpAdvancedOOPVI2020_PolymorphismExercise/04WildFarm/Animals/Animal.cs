using _04WildFarm.Foods;
using System;
using System.Linq;

namespace _04WildFarm.Animals
{
    public abstract class Animal
    {
        private const string PronouncedSound = "...";
        private const double WeightIncreasingPercent = 1;
        private readonly string[] PossibleEatenFoods = new string[] { "Vegetable", "Fruit", "Meat", "Seeds" };

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        protected string Name { get; private set; }

        protected double Weight { get; set; }

        protected int FoodEaten { get; set; }
        
        public virtual string ProducedSound => PronouncedSound;

        public virtual double WeightIncreasingRate => WeightIncreasingPercent;

        public virtual string[] EatenFoods => PossibleEatenFoods;

        public string ProduceSound()
        {
            return this.ProducedSound;
        }

        public void Eat(Food food)
        {
            string foodName = food.GetType().Name;
            int foodQuantity = food.Quantity;
            if (!this.EatenFoods.Contains(foodName))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodName}!");
            }

            this.FoodEaten += foodQuantity;
            this.Weight += foodQuantity * this.WeightIncreasingRate;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
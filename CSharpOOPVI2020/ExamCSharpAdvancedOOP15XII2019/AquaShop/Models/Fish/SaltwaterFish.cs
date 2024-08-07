﻿namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int InitialSize = 5;
        private const int EatIncreasingSize = 2;

        public SaltwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            this.Size = InitialSize;
        }

        public override void Eat()
        {
            this.Size += EatIncreasingSize;
        }
    }
}
﻿using System;

namespace _03Template
{
    public abstract class Bread
    {
        public void Make()
        {
            this.MixIngredients();
            this.Bake();
            this.Slice();
        }

        public abstract void MixIngredients();

        public abstract void Bake();

        public virtual void Slice()
        {
            Console.WriteLine($"Slicing the {this.GetType().Name} bread!");
        }
    }
}
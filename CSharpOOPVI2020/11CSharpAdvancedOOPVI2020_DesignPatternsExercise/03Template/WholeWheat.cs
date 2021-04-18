using System;

namespace _03Template
{
    public class WholeWheat : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for Whole wheat bread.");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the Whole wheat bread. (15 minutes)");
        }
    }
}
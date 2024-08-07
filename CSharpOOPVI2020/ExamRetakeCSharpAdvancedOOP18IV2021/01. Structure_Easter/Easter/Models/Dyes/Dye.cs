﻿using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private const int PowerDecreasingNumber = 10;

        private int power;

        public Dye(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get { return this.power; }
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.power = value;
            }
        }

        public bool IsFinished()
        {
            return this.Power == 0;
        }

        public void Use()
        {
            this.Power -= PowerDecreasingNumber;
        }
    }
}
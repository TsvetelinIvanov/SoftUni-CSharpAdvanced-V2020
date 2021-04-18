﻿namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int FiredBulletsCount = 1;

        public Pistol(string name, int bulletsCount) : base(name, bulletsCount)
        {

        }

        public override int Fire()
        {
            if (this.BulletsCount >= FiredBulletsCount)
            {
                BulletsCount -= FiredBulletsCount;

                return FiredBulletsCount;
            }
            else
            {
                return 0;
            }            
        }
    }
}
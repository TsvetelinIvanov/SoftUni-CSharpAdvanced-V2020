namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int FiredBulletsCount = 10;

        public Rifle(string name, int bulletsCount) : base(name, bulletsCount)
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
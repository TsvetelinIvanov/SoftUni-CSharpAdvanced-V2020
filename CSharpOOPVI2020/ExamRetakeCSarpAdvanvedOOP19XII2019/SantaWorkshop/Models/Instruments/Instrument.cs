using SantaWorkshop.Models.Instruments.Contracts;

namespace SantaWorkshop.Models.Instruments
{
    public class Instrument : IInstrument
    {
        private const int PowerDecreasingNumber = 10;

        private int power;

        public Instrument(int power)
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

        public bool IsBroken()
        {
            return this.Power == 0;
        }

        public void Use()
        {
            this.Power -= PowerDecreasingNumber;
        }
    }
}
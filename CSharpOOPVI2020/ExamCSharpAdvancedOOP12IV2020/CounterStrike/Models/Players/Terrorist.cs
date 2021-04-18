using CounterStrike.Models.Guns.Contracts;

namespace CounterStrike.Models.Players
{
    public class Terrorist : Player
    {
        public Terrorist(string name, int health, int armor, IGun gun) : base(name, health, armor, gun)
        {

        }
    }
}
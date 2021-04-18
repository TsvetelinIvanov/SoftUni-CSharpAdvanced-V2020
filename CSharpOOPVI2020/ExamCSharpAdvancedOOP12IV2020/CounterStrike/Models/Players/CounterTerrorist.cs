using CounterStrike.Models.Guns.Contracts;

namespace CounterStrike.Models.Players
{
    public class CounterTerrorist : Player
    {
        public CounterTerrorist(string name, int health, int armor, IGun gun) : base(name, health, armor, gun)
        {

        }
    }
}
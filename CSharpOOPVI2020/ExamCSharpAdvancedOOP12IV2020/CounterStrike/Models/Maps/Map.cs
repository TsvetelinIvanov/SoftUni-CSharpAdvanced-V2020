using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            ICollection<Terrorist> terrorists = players.Where(p => p is Terrorist).Select(t => (Terrorist)t).ToArray();
            ICollection<CounterTerrorist> counterTerrorists = players.Where(p => p is CounterTerrorist).Select(ct => (CounterTerrorist)ct).ToArray();

            while (terrorists.Count(t => t.IsAlive) > 0 && counterTerrorists.Count(ct => ct.IsAlive) > 0)
            {
                ICollection<Terrorist> aliveTerrorists = terrorists.Where(t => t.IsAlive).ToArray();
                ICollection<CounterTerrorist> aliveCounterTerrorists = counterTerrorists.Where(ct => ct.IsAlive).ToArray();

                foreach (Terrorist terrorist in aliveTerrorists)
                {
                    int demagePointsCount = terrorist.Gun.Fire();
                    foreach (CounterTerrorist counterTerrorist in aliveCounterTerrorists)
                    {
                        counterTerrorist.TakeDamage(demagePointsCount);
                    }
                }

                aliveCounterTerrorists = counterTerrorists.Where(ct => ct.IsAlive).ToArray();
                if (aliveCounterTerrorists.Count <= 0)
                {
                    break;
                }

                foreach (CounterTerrorist counterTerrorist in aliveCounterTerrorists)
                {
                    int demagePointsCount = counterTerrorist.Gun.Fire();
                    foreach (Terrorist terrorist in aliveTerrorists)
                    {
                       terrorist.TakeDamage(demagePointsCount);
                    }
                }
            }

            string winner = "Terrorist wins!";
            if (counterTerrorists.Count(ct => ct.IsAlive) > 0)
            {
                winner = "Counter Terrorist wins!";
            }

            return winner;
        }
    }
}
using CounterStrike.Models.Players.Contracts;
using System.Collections.Generic;

namespace CounterStrike.Models.Maps.Contracts
{
    public interface IMap
    {
        string Start(ICollection<IPlayer> players);
    }
}
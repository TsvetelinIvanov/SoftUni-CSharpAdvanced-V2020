using System.Collections.Generic;

namespace _07MilitaryElite.Interfaces
{
    public interface ICommando
    {
        List<IMission> Missions { get; }
    }
}
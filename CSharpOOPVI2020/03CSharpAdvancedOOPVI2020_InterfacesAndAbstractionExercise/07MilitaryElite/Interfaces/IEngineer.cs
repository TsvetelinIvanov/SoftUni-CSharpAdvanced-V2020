using System.Collections.Generic;

namespace _07MilitaryElite.Interfaces
{
    public interface IEngineer
    {
        List<IRepair> Repairs { get; }
    }
}
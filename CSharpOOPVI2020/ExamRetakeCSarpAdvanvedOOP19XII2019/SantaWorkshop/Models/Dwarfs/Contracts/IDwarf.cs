using SantaWorkshop.Models.Instruments.Contracts;
using System.Collections.Generic;

namespace SantaWorkshop.Models.Dwarfs.Contracts
{
    public interface IDwarf
    {
        string Name { get; }

        int Energy { get; }

        ICollection<IInstrument> Instruments { get; }

        abstract void Work();

        void AddInstrument(IInstrument instrument);
    }
}
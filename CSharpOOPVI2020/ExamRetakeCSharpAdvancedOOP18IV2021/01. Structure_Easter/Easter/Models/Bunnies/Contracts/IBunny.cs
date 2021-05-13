using System.Collections.Generic;
using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Bunnies.Contracts
{
    public interface IBunny
    {
        string Name { get; }

        int Energy { get; }

        ICollection<IDye> Dyes { get; }

        abstract void Work();

        void AddDye(IDye dye);
    }
}
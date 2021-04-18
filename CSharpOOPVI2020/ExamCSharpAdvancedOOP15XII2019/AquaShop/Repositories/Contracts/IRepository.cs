using System.Collections.Generic;

namespace AquaShop.Repositories.Contracts
{
    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }

        void Add(T model);

        bool Remove(T model);

        T FindByType(string type);
    }
}
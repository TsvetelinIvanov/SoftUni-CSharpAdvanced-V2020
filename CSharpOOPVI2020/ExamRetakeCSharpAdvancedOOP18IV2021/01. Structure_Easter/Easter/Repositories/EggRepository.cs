using System.Collections.Generic;
using Easter.Repositories.Contracts;
using Easter.Models.Eggs.Contracts;
using System.Linq;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly ICollection<IEgg> eggs;

        public EggRepository()
        {
            this.eggs = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => this.eggs as IReadOnlyCollection<IEgg>;

        public void Add(IEgg egg)
        {
            this.eggs.Add(egg);
        }

        public IEgg FindByName(string name)
        {
            return this.eggs.FirstOrDefault(e => e.Name == name);
        }

        public bool Remove(IEgg egg)
        {
            return this.eggs.Remove(egg);
        }
    }
}
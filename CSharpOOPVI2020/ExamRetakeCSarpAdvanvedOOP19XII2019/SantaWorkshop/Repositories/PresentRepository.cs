using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {
        private readonly List<IPresent> presents;

        public PresentRepository()
        {
            this.presents = new List<IPresent>();
        }

        public IReadOnlyCollection<IPresent> Models => this.presents as IReadOnlyCollection<IPresent>;

        public void Add(IPresent present)
        {
            this.presents.Add(present);
        }

        public IPresent FindByName(string name)
        {
            return this.presents.FirstOrDefault(p => p.Name == name);
        }

        public bool Remove(IPresent present)
        {
            return this.presents.Remove(present);
        }
    }
}
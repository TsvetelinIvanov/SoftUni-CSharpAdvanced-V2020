using System.Collections.Generic;
using Easter.Repositories.Contracts;
using Easter.Models.Bunnies.Contracts;
using System.Linq;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly ICollection<IBunny> bunnies;

        public BunnyRepository()
        {
            this.bunnies = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => this.bunnies as IReadOnlyCollection<IBunny>;

        public void Add(IBunny bunny)
        {
            this.bunnies.Add(bunny);
        }

        public IBunny FindByName(string name)
        {
            return this.bunnies.FirstOrDefault(b => b.Name == name);
        }

        public bool Remove(IBunny bunny)
        {
            return this.bunnies.Remove(bunny);
        }
    }
}
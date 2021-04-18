using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly List<IDwarf> dwarfs;

        public DwarfRepository()
        {
            this.dwarfs = new List<IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models => this.dwarfs as IReadOnlyCollection<IDwarf>;

        public void Add(IDwarf dwarf)
        {
            this.dwarfs.Add(dwarf);
        }

        public IDwarf FindByName(string name)
        {
            return this.dwarfs.FirstOrDefault(d => d.Name == name);
        }

        public bool Remove(IDwarf dwarf)
        {
            return this.dwarfs.Remove(dwarf);
        }
    }
}
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> drivers;

        public DriverRepository()
        {
            this.drivers = new List<IDriver>();
        }

        public void Add(IDriver driver)
        {
            this.drivers.Add(driver);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.drivers.AsReadOnly();
        }

        public IDriver GetByName(string name)
        {
            return this.drivers.FirstOrDefault(d => d.Name == name);
        }

        public bool Remove(IDriver driver)
        {
            return this.drivers.Remove(driver);
        }
    }
}
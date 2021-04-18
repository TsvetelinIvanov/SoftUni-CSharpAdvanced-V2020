using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> cars;

        public CarRepository()
        {
            this.cars = new List<ICar>();
        }

        public void Add(ICar car)
        {
            this.cars.Add(car);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return this.cars.AsReadOnly();
        }

        public ICar GetByName(string modelName)
        {
            return this.cars.FirstOrDefault(c => c.Model == modelName);
        }

        public bool Remove(ICar car)
        {
            return this.cars.Remove(car);
        }
    }
}
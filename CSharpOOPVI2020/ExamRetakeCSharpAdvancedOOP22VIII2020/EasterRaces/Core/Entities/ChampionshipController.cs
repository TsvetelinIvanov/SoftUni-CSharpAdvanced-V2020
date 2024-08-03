using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private const int MinParticipantsCount = 3;

        private CarRepository carRepository;
        private DriverRepository driverRepository;
        private RaceRepository raceRepository;

        public ChampionshipController()
        {
            this.carRepository = new CarRepository();
            this.driverRepository = new DriverRepository();
            this.raceRepository = new RaceRepository();
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            switch (type)
            {
                case "Muscle":
                    car = new MuscleCar(model, horsePower);
                    break;
                case "Sports":
                    car = new SportsCar(model, horsePower);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.CarInvalid);
            }

            if (this.carRepository.GetAll().Any(c => c.Model == car.Model))
            {
                throw new ArgumentException(ExceptionMessages.CarExists, car.Model);
            }

            this.carRepository.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, car.Model);
        }

        public string CreateDriver(string driverName)
        {
            if (this.driverRepository.GetAll().Any(d => d.Name == driverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            Driver driver = new Driver(driverName);
            this.driverRepository.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driver.Name);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.driverRepository.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            ICar car = this.carRepository.GetByName(carModel);
            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driver.Name, car.Model);
        }

        public string CreateRace(string name, int laps)
        {
            Race race = new Race(name, laps);
            if (this.raceRepository.GetAll().Any(r => r.Name == race.Name && r.Laps == race.Laps))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, race.Name));
            }

            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, race.Name);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IDriver driver = this.driverRepository.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driver.Name, race.Name);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < MinParticipantsCount)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, race.Name, MinParticipantsCount));
            }

            IDriver[] winners = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).Take(MinParticipantsCount).ToArray();

            this.raceRepository.Remove(race);

            StringBuilder raceWinnerBuilder = new StringBuilder();
            raceWinnerBuilder.AppendLine(string.Format(OutputMessages.DriverFirstPosition, winners[0].Name, race.Name));
            raceWinnerBuilder.AppendLine(string.Format(OutputMessages.DriverSecondPosition, winners[1].Name, race.Name));
            raceWinnerBuilder.Append(string.Format(OutputMessages.DriverThirdPosition, winners[2].Name, race.Name));

            return raceWinnerBuilder.ToString();
        }
    }
}

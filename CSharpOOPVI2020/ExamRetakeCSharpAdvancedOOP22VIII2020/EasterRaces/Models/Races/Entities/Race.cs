using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int MinNameSymbols = 5;
        private const int MinLaps = 1;

        private string name;
        private int laps;
        private List<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinNameSymbols)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MinNameSymbols));
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get { return this.laps; }
            private set
            {
                if (value < MinLaps)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, MinLaps));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers.AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(driver), ExceptionMessages.DriverInvalid);
            }

            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (this.drivers.Contains(driver))
            {
                throw new ArgumentNullException(nameof(driver), string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            this.drivers.Add(driver);
        }
    }
}

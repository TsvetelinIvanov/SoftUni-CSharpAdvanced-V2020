using NUnit.Framework;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private const string ExistingDriver = "Driver {0} is already added.";
        private const string DriverInvalid = "Driver cannot be null.";
        private const string DriverAdded = "Driver {0} added in race.";
        private const int MinParticipants = 2;
        private const string RaceInvalid = "The race cannot start with less than {0} participants.";

        private readonly UnitCar car1 = new UnitCar("Car1", 101, 101.01);
        private readonly UnitCar car2 = new UnitCar("Car2", 101, 101.02);
        private readonly UnitCar car3 = new UnitCar("Car3", 101, 101.03);

        private UnitDriver driver1;
        private UnitDriver driver2;
        private UnitDriver driver3;

        private RaceEntry raceEntry;


        [SetUp]
        public void Setup()
        {
            this.driver1 = new UnitDriver("Driver1", car1);
            this.driver2 = new UnitDriver("Driver2", car2);
            this.driver3 = new UnitDriver("Driver3", car3);

            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void CarInitalizeCorrectly()
        {
            Assert.AreEqual("Car1", this.car1.Model);
            Assert.AreEqual(101, this.car1.HorsePower);
            Assert.AreEqual(101.01, this.car1.CubicCentimeters);
        }

        [Test]
        public void DriverInitalizeCorrectly()
        {
            Assert.AreEqual("Driver1", this.driver1.Name);
            Assert.AreEqual(this.car1, this.driver1.Car);
        }

        [Test]
        public void DriverThrowsIfNullForName()
        {
            Assert.That(() => this.driver1 = new UnitDriver(null, this.car1), Throws.ArgumentNullException);
        }

        [Test]
        public void RaceEntryInitalizeWihEmpyCollection()
        {
            Assert.AreEqual(0, this.raceEntry.Counter);
        }

        [Test]
        public void AddDriverWorksCorrectly()
        {
            string expectedResult1 = string.Format(DriverAdded, this.driver1.Name);
            string actualResult1 = this.raceEntry.AddDriver(this.driver1);

            string expectedResult2 = string.Format(DriverAdded, this.driver2.Name);
            string actualResult2 = this.raceEntry.AddDriver(this.driver2);

            Assert.AreEqual(expectedResult1, actualResult1);
            Assert.AreEqual(2, this.raceEntry.Counter);

            Assert.AreEqual(expectedResult2, actualResult2);
            Assert.AreEqual(2, this.raceEntry.Counter);
        }

        [Test]
        public void AddDriverThrowsIfDriverIsNull()
        {
            string actualResult = this.raceEntry.AddDriver(this.driver1);

            Assert.That(() => this.raceEntry.AddDriver(null), Throws.InvalidOperationException.With.Message.EqualTo(DriverInvalid));
        }

        [Test]
        public void AddDriverThrowsIfExistingDriver()
        {
            string actualResult1 = this.raceEntry.AddDriver(this.driver1);
            string actualResult2 = this.raceEntry.AddDriver(this.driver2);

            Assert.That(() => this.raceEntry.AddDriver(this.driver1), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(ExistingDriver, this.driver1.Name)));
        }

        [Test]
        public void CalculateAverageHorseWorksPowerCorrectly()
        {
            string actualResult1 = this.raceEntry.AddDriver(this.driver1);
            string actualResult2 = this.raceEntry.AddDriver(this.driver2);
            string actualResult3 = this.raceEntry.AddDriver(this.driver3);

            double expectedResult = 101;
            double actualResult = this.raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CalculateAverageHorsePowerWorksCorrectlyWithMinParticipants()
        {
            string actualResult1 = this.raceEntry.AddDriver(this.driver1);
            string actualResult2 = this.raceEntry.AddDriver(this.driver2);

            double expectedResult = 101;
            double actualResult = this.raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CalculateAverageHorsePowerThrowsIfBelowMinParticipants()
        {
            string actualResult1 = this.raceEntry.AddDriver(this.driver1);

            Assert.That(() => this.raceEntry.CalculateAverageHorsePower(), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(RaceInvalid, MinParticipants)));
        }
    }
}
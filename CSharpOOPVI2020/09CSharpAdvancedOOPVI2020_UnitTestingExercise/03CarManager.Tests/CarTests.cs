using _03CarManager;//For Judge must be commented: using _03CarManager; and <ProjectReference Include="..\03CarManager\03CarManager.csproj" /> in 03CarManager.Tests.csproj file
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private const string DefaultMake = "Renaut";
        private const string NullMake = null;
        private const string EmptytMake = "";
        private const string EmptytMakeExceptionMessage = "Make cannot be null or empty!";
        private const string DefaultModel = "5";
        private const string NulltModel = null;
        private const string EmptytModel = "";
        private const string EmptytModelExceptionMessage = "Model cannot be null or empty!";
        private const double DefaultFuelConsumption = 5;
        private const double ZeroFuelConsumption = 0;
        private const double NegativeFuelConsumption = -5;
        private const string InvalidFuelConsumptionExceptionMessage = "Fuel consumption cannot be zero or negative!";
        private const double DefaultFuelAmount = 0;
        private const double DefaultFuelCapacity = 40;
        private const double ZeroFuelCapacity = 0;
        private const double NegativeFuelCapacity = -40;
        private const string InvalidFuelCapacityExceptionMessage = "Fuel capacity cannot be zero or negative!";       
        private const double FuelAmountToRefuel = 15;
        private const double ZeroAmountToRefuel = 0;
        private const double NegativeAmountToRefuel = -15;
        private const string InvalidFuelAmountExceptionMessage = "Fuel amount cannot be zero or negative!";
        private const double Distance = 100;
        private const double FuelAmountAfterDistance = 10;
        private const string ImposibleDriveExceptionMessage = "You don't have enough fuel to drive!";

        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car(DefaultMake, DefaultModel, DefaultFuelConsumption, DefaultFuelCapacity);
        }

        [Test]
        public void FuelAmountEqualsDefault()
        {
            Assert.AreEqual(DefaultFuelAmount, this.car.FuelAmount);
        }        

        [Test]
        public void MakeEqualsGivenDefault()
        {
            Assert.AreEqual(DefaultMake, this.car.Make);
        }

        [Test]
        public void NullMakeThrowsException()
        {
            Assert.That(() => this.car = new Car(NullMake, DefaultModel, DefaultFuelConsumption, DefaultFuelCapacity), Throws.ArgumentException.With.Message.EqualTo(EmptytMakeExceptionMessage));
        }

        [Test]
        public void EmptyMakeThrowsException()
        {
            Assert.That(() => this.car = new Car(EmptytMake, DefaultModel, DefaultFuelConsumption, DefaultFuelCapacity), Throws.ArgumentException.With.Message.EqualTo(EmptytMakeExceptionMessage));
        }

        [Test]
        public void ModelEqualsGivenDefault()
        {
            Assert.AreEqual(DefaultModel, this.car.Model);
        }

        [Test]
        public void NullModelThrowsException()
        {
            Assert.That(() => this.car = new Car(DefaultMake, NulltModel, DefaultFuelConsumption, DefaultFuelCapacity), Throws.ArgumentException.With.Message.EqualTo(EmptytModelExceptionMessage));
        }

        [Test]
        public void EmptyModelThrowsException()
        {
            Assert.That(() => this.car = new Car(DefaultMake, EmptytModel, DefaultFuelConsumption, DefaultFuelCapacity), Throws.ArgumentException.With.Message.EqualTo(EmptytModelExceptionMessage));
        }

        [Test]
        public void FuelConsumptionEqualsGivenDefault()
        {
            Assert.AreEqual(DefaultFuelConsumption, this.car.FuelConsumption);
        }

        [Test]
        public void ZeroFuelConsumptionThrowsException()
        {
            Assert.That(() => this.car = new Car(DefaultMake, DefaultModel, ZeroFuelConsumption, DefaultFuelCapacity), Throws.ArgumentException.With.Message.EqualTo(InvalidFuelConsumptionExceptionMessage));
        }

        [Test]
        public void NegativeFuelConsumptionThrowsException()
        {
            Assert.That(() => this.car = new Car(DefaultMake, DefaultModel, NegativeFuelConsumption, DefaultFuelCapacity), Throws.ArgumentException.With.Message.EqualTo(InvalidFuelConsumptionExceptionMessage));
        }

        [Test]
        public void FuelCapacityEqualsGivenDefault()
        {
            Assert.AreEqual(DefaultFuelCapacity, this.car.FuelCapacity);
        }

        [Test]
        public void ZeroFuelCapacityThrowsException()
        {
            Assert.That(() => this.car = new Car(DefaultMake, DefaultModel, DefaultFuelConsumption, ZeroFuelCapacity), Throws.ArgumentException.With.Message.EqualTo(InvalidFuelCapacityExceptionMessage));
        }

        [Test]
        public void NegativeFuelCapacityThrowsException()
        {
            Assert.That(() => this.car = new Car(DefaultMake, DefaultModel, DefaultFuelConsumption, NegativeFuelCapacity), Throws.ArgumentException.With.Message.EqualTo(InvalidFuelCapacityExceptionMessage));
        }

        [Test]
        public void RefuelWithFuelAmountToRefuel()
        {
            this.car.Refuel(FuelAmountToRefuel);

            Assert.AreEqual(FuelAmountToRefuel, car.FuelAmount);
        }

        [Test]
        public void RefuelWithFuelAmountBiggerThanCapacityRefuelQualToCapacity()
        {
            this.car.Refuel(FuelAmountToRefuel);
            this.car.Refuel(FuelAmountToRefuel);
            this.car.Refuel(FuelAmountToRefuel);

            Assert.AreEqual(DefaultFuelCapacity, car.FuelAmount);
        }

        [Test]
        public void RefuelThrowsIfRefuelAmountToRefuelIsZero()
        {
            Assert.That(() => this.car.Refuel(ZeroAmountToRefuel), Throws.ArgumentException.With.Message.EqualTo(InvalidFuelAmountExceptionMessage));
        }

        [Test]
        public void RefuelThrowsIfRefuelAmountToRefuelIsNegative()
        {
            Assert.That(() => this.car.Refuel(NegativeAmountToRefuel), Throws.ArgumentException.With.Message.EqualTo(InvalidFuelAmountExceptionMessage));
        }

        [Test]
        public void DriveDecreasesFuelAmountWithConsumpion()
        {
            this.car.Refuel(FuelAmountToRefuel);
            this.car.Drive(Distance);

            Assert.AreEqual(FuelAmountAfterDistance, this.car.FuelAmount);
        }

        [Test]
        public void DriveThrowsIfDrivingImposible()
        {
            Assert.That(() => this.car.Drive(Distance), Throws.InvalidOperationException.With.Message.EqualTo(ImposibleDriveExceptionMessage));
        }
    }
}
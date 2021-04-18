using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class ComputerManagerTests
    {
        private const string CanNotBeNullExceptionMessage = "Can not be null!";
        private const string ExistentComputertExceptionMessage = "This computer already exists.";
        private const string InexistantComputerExceptionMessage = "There is no computer with this manufacturer and model.";

        private readonly Computer computer1 = new Computer("Manufacturer1", "Model1", 11.01m);
        private readonly Computer computer2 = new Computer("Manufacturer1", "Model2", 12.02m);
        private readonly Computer computer3 = new Computer("Manufacturer3", "Model3", 13.03m);

        private ComputerManager computerManager;

        [SetUp]
        public void Initialization()
        {
            this.computerManager = new ComputerManager();
        }

        [Test]
        public void ComputerInitializeCorrectly()
        {
            Assert.AreEqual("Manufacturer1", this.computer1.Manufacturer);
            Assert.AreEqual("Model1", this.computer1.Model);
            Assert.AreEqual(11.01m, this.computer1.Price);
        }

        [Test]
        public void InitializationWithEmptyCollection()
        {
            Assert.AreEqual(0, this.computerManager.Count);
        }

        [Test]
        public void InitializationReturnsCorrectlyCollection()
        {
            this.computerManager.AddComputer(this.computer1);
            this.computerManager.AddComputer(this.computer2);

            Computer computer = this.computerManager.Computers.FirstOrDefault(c => c.Model == this.computer1.Model);

            Assert.AreEqual(2, this.computerManager.Count);
            Assert.AreEqual(this.computer1.Manufacturer, computer.Manufacturer);
            Assert.AreEqual(this.computer1.Model, computer.Model);
            Assert.AreEqual(this.computer1.Price, computer.Price);
        }

        [Test]
        public void AddComputerWorksCorrectly()
        {
            this.computerManager.AddComputer(this.computer1);
            this.computerManager.AddComputer(this.computer2);
            this.computerManager.AddComputer(this.computer3);

            Assert.AreEqual(3, this.computerManager.Count);
            Assert.IsTrue(this.computerManager.Computers.Contains(this.computer1));
            Assert.IsTrue(this.computerManager.Computers.Contains(this.computer2));
            Assert.IsTrue(this.computerManager.Computers.Contains(this.computer3));
        }

        [Test]
        public void AddComputerThrousIfNull()
        {
            Assert.That(() => this.computerManager.AddComputer(null), Throws.ArgumentNullException);
        }

        [Test]
        public void AddComputerThrousIfExistentComputer()
        {
            this.computerManager.AddComputer(this.computer1);
            this.computerManager.AddComputer(this.computer2);
            this.computerManager.AddComputer(this.computer3);

            Assert.That(() => this.computerManager.AddComputer(this.computer1), Throws.ArgumentException.With.Message.EqualTo(ExistentComputertExceptionMessage));
        }

        [Test]
        public void GetComputerWorksCorrectly()
        {
            this.computerManager.AddComputer(this.computer1);
            this.computerManager.AddComputer(this.computer2);
            this.computerManager.AddComputer(this.computer3);

            Computer computer = this.computerManager.GetComputer(this.computer1.Manufacturer, this.computer1.Model);

            Assert.AreEqual(this.computer1, computer);
        }

        [Test]
        public void GetComputerThrousIfNullManufacturer()
        {
            Assert.That(() => this.computerManager.GetComputer(null, this.computer1.Model), Throws.ArgumentNullException);
        }

        [Test]
        public void GetComputerThrousIfNullModel()
        {
            Assert.That(() => this.computerManager.GetComputer(this.computer1.Manufacturer, null), Throws.ArgumentNullException);
        }

        public void GetComputerThrousIfInexistantComputer()
        {
            this.computerManager.AddComputer(this.computer1);
            this.computerManager.AddComputer(this.computer2);

            Assert.That(() => this.computerManager.GetComputer(this.computer3.Manufacturer, this.computer3.Model), Throws.ArgumentException.With.Message.EqualTo(InexistantComputerExceptionMessage));
            Assert.That(() => this.computerManager.GetComputer(this.computer3.Manufacturer, this.computer1.Model), Throws.ArgumentException.With.Message.EqualTo(InexistantComputerExceptionMessage));
            Assert.That(() => this.computerManager.GetComputer(this.computer1.Manufacturer, this.computer3.Model), Throws.ArgumentException.With.Message.EqualTo(InexistantComputerExceptionMessage));
        }

        [Test]
        public void RemoveComputerWorksCorrectly()
        {
            this.computerManager.AddComputer(this.computer1);
            this.computerManager.AddComputer(this.computer2);
            this.computerManager.AddComputer(this.computer3);

            Computer computer = this.computerManager.RemoveComputer(this.computer1.Manufacturer, this.computer1.Model);

            Assert.AreEqual(this.computer1, computer);
            Assert.IsFalse(this.computerManager.Computers.Contains(this.computer1));
        }

        [Test]
        public void RemoveComputerThrousIfNullManufacturer()
        {
            Assert.That(() => this.computerManager.RemoveComputer(null, this.computer1.Model), Throws.ArgumentNullException);
        }

        [Test]
        public void RemovComputerThrousIfNullModel()
        {
            Assert.That(() => this.computerManager.RemoveComputer(this.computer1.Manufacturer, null), Throws.ArgumentNullException);
        }

        public void RemoveComputerThrousIfInexistantComputer()
        {
            this.computerManager.AddComputer(this.computer1);
            this.computerManager.AddComputer(this.computer2);

            Assert.That(() => this.computerManager.RemoveComputer(this.computer3.Manufacturer, this.computer3.Model), Throws.ArgumentException.With.Message.EqualTo(InexistantComputerExceptionMessage));
            Assert.That(() => this.computerManager.RemoveComputer(this.computer3.Manufacturer, this.computer1.Model), Throws.ArgumentException.With.Message.EqualTo(InexistantComputerExceptionMessage));
            Assert.That(() => this.computerManager.RemoveComputer(this.computer1.Manufacturer, this.computer3.Model), Throws.ArgumentException.With.Message.EqualTo(InexistantComputerExceptionMessage));
        }

        [Test]
        public void GetComputersByManufacturerReturnsComputersWithGivenManufacturer()
        {
            this.computerManager.AddComputer(this.computer1);
            this.computerManager.AddComputer(this.computer2);
            this.computerManager.AddComputer(this.computer3);

            ICollection<Computer> computers = this.computerManager.GetComputersByManufacturer(this.computer1.Manufacturer);

            Assert.AreEqual(2, computers.Count);
            Assert.IsTrue(computers.Contains(this.computer1));
            Assert.IsTrue(computers.Contains(this.computer2));
            Assert.IsFalse(computers.Contains(this.computer3));
        }

        public void GetComputersByManufacturerReturnsEmptyCollectionIfInexistantManufacturer()
        {
            this.computerManager.AddComputer(this.computer1);
            this.computerManager.AddComputer(this.computer2);

            ICollection<Computer> computers = this.computerManager.GetComputersByManufacturer(this.computer3.Manufacturer);

            Assert.AreEqual(0, computers.Count);
        }
    }
}
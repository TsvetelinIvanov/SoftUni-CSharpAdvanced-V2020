using NUnit.Framework;
using System.Linq;

namespace Computers.Tests
{
    public class ComputerTests
    {
        private const string ComputerName = "Computer";
        private const string InvalidNameExceptionMessage = "Name cannot be null or empty! (Parameter 'Name')";
        private const string AddNullExceptionMessage = "Cannot add null!";

        private readonly Part part1 = new Part("Part1", 11.01m);
        private readonly Part part2 = new Part("Part2", 12.02m);
        private readonly Part part3 = new Part("Part3", 13.03m);        

        private Computer computer;

        [SetUp]
        public void Initialization()
        {
            this.computer = new Computer(ComputerName);
        }

        [Test]
        public void InitializationWithEmptyCollection()
        {
            Assert.AreEqual(0, this.computer.Parts.Count);
        }

        [Test]
        public void InitializationWithGivenName()
        {
            Assert.AreEqual(ComputerName, this.computer.Name);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        public void InitializationWithInvalidNameThrows(string invalidName)
        {
            Assert.That(() => this.computer = new Computer(invalidName), Throws.ArgumentNullException.With.Message.EqualTo(InvalidNameExceptionMessage));
        }

        [Test]
        public void AddPartWorksCorrectly()
        {
            this.computer.AddPart(this.part1);
            this.computer.AddPart(this.part2);
            this.computer.AddPart(this.part3);

            Assert.AreEqual(3, this.computer.Parts.Count);
            Assert.IsTrue(this.computer.Parts.Contains(this.part1));
            Assert.IsTrue(this.computer.Parts.Contains(this.part2));
            Assert.IsTrue(this.computer.Parts.Contains(this.part3));
        }

        [Test]
        public void AddPartThrowsIfNull()
        {
            Assert.That(() => this.computer.AddPart(null), Throws.InvalidOperationException.With.Message.EqualTo(AddNullExceptionMessage));
        }

        [Test]
        public void RemovePartRemovesCorrectlyAndReturnsTrue()
        {
            this.computer.AddPart(this.part1);
            this.computer.AddPart(this.part2);
            this.computer.AddPart(this.part3);

            bool isRemoved = this.computer.RemovePart(this.part1);

            Assert.IsTrue(isRemoved);
            Assert.IsFalse(this.computer.Parts.Contains(this.part1));
        }

        [Test]
        public void RemovePartsReturnsFalseIfInexistantPart()
        {
            this.computer.AddPart(this.part1);
            this.computer.AddPart(this.part2);

            Assert.IsFalse(this.computer.RemovePart(this.part3));
        }

        [Test]
        public void GetPartReturnsAppropriatePart()
        {
            this.computer.AddPart(this.part1);
            this.computer.AddPart(this.part2);
            this.computer.AddPart(this.part3);

            Part part = this.computer.GetPart(this.part1.Name);

            Assert.AreEqual(this.part1, part);
        }

        [Test]
        public void GetPartReturnsNullIfInexistant()
        {
            this.computer.AddPart(this.part1);
            this.computer.AddPart(this.part2);

            Part part = this.computer.GetPart(this.part3.Name);

            Assert.IsNull(part);
        }

        [Test]
        public void TotalPriceWorksCorrectly()
        {
            this.computer.AddPart(this.part1);
            this.computer.AddPart(this.part2);
            this.computer.AddPart(this.part3);

            decimal ecpectedPrice = 36.06m;
            decimal actualPrice = this.computer.TotalPrice;

            Assert.AreEqual(ecpectedPrice, actualPrice);
        }

        [Test]
        public void TotalPriceIs0IfEmptyCollection()
        {
            Assert.AreEqual(0, this.computer.TotalPrice);
        }
    }
}
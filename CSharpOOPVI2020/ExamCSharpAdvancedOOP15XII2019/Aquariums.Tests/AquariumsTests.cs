using NUnit.Framework;
using System.Linq;

namespace Aquariums.Tests
{
    public class AquariumsTests
    {
        private const string AquariumName = "Aquarium";
        private const int AquariumCapacity = 5;
        private const string InvalidNameExceptionMessage = "Invalid aquarium name!";
        private const string InvalidCapacityExceptionMessage = "Invalid aquarium capacity!";
        private const string FullAquariumAddingExceptionMessage = "Aquarium is full!";
        private const string InExistingFishExceptionMessage = "Fish with the name {0} doesn't exist!";
        private const string ReportOutputMessage = "Fish available at {0}: {1}";

        private readonly Fish fish1 = new Fish("Fish1");
        private readonly Fish fish2 = new Fish("Fish2");
        private readonly Fish fish3 = new Fish("Fish3");

        private Aquarium aquarium;

        [SetUp]
        public void Initialization()
        {
            this.aquarium = new Aquarium(AquariumName, AquariumCapacity);
        }

        [Test]
        public void ConstructorWorksCorrectly()
        {
            Assert.AreEqual(AquariumName, this.aquarium.Name);
            Assert.AreEqual(AquariumCapacity, this.aquarium.Capacity);
            Assert.AreEqual(0, this.aquarium.Count);
        }

        [TestCase(null)]
        [TestCase("")]
        public void InvalidNameThrows(string invalidName)
        {
            Assert.That(() => this.aquarium = new Aquarium(invalidName, AquariumCapacity), Throws.ArgumentNullException.With.Message.EqualTo(InvalidNameExceptionMessage + " (Parameter 'value')"));
        }

        [TestCase(-10)]
        [TestCase(-1)]
        public void InvalidCapacityThrows(int invalidCapacity)
        {
            Assert.That(() => this.aquarium = new Aquarium(AquariumName, invalidCapacity), Throws.ArgumentException.With.Message.EqualTo(InvalidCapacityExceptionMessage));
        }

        [Test]
        public void AddWorksCorrectly()
        {
            this.aquarium.Add(this.fish1);
            this.aquarium.Add(this.fish2);
            this.aquarium.Add(this.fish3);

            Assert.AreEqual(3, this.aquarium.Count);            
        }

        [Test]
        public void AddThrowsIfFull()
        {
            this.aquarium.Add(this.fish1);
            this.aquarium.Add(this.fish2);
            this.aquarium.Add(this.fish3);
            this.aquarium.Add(this.fish1);
            this.aquarium.Add(this.fish2);

            Assert.That(() => this.aquarium.Add(fish3), Throws.InvalidOperationException.With.Message.EqualTo(FullAquariumAddingExceptionMessage));
        }

        [Test]
        public void RemoveFishWorksCorrectly()
        {
            this.aquarium.Add(this.fish1);
            this.aquarium.Add(this.fish2);
            this.aquarium.Add(this.fish3);

            this.aquarium.RemoveFish(fish1.Name);
            this.aquarium.RemoveFish(fish2.Name);

            Assert.AreEqual(1, this.aquarium.Count);
        }

        [Test]
        public void RemoveFishThrowsIfInexistingFish()
        {
            this.aquarium.Add(this.fish1);
            this.aquarium.Add(this.fish2);

            Assert.That(() => this.aquarium.RemoveFish(fish3.Name), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(InExistingFishExceptionMessage, fish3.Name)));
        }

        [Test]
        public void SellFishWorksCorrectly()
        {
            this.aquarium.Add(this.fish1);
            this.aquarium.Add(this.fish2);
            this.aquarium.Add(this.fish3);

            Fish fish = this.aquarium.SellFish(fish1.Name);
            
            Assert.AreEqual(fish1, fish);
            Assert.IsFalse(fish.Available);
        }

        [Test]
        public void SellFishThrowsIfInexistingFish()
        {
            this.aquarium.Add(this.fish1);
            this.aquarium.Add(this.fish2);

            Assert.That(() => this.aquarium.SellFish(fish3.Name), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(InExistingFishExceptionMessage, fish3.Name)));
        }

        [Test]
        public void ReportWorksCorrectlyWithEmptyAquarium()
        {
            string expectedReport = string.Format(ReportOutputMessage, this.aquarium.Name, null);
            string actualReport = this.aquarium.Report();

            Assert.AreEqual(expectedReport, actualReport);
        }

        [Test]
        public void ReportWorksCorrectlyWithNonEmptyAquarium()
        {
            this.aquarium.Add(this.fish1);
            this.aquarium.Add(this.fish2);
            this.aquarium.Add(this.fish3);

            string fishNames = $"{fish1.Name}, {fish2.Name}, {fish3.Name}";
            string expectedReport = string.Format(ReportOutputMessage, this.aquarium.Name, fishNames);
            string actualReport = this.aquarium.Report();

            Assert.AreEqual(expectedReport, actualReport);
        }
    }
}
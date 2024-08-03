namespace Presents.Tests
{
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class PresentsTests
    {
        private const string NullPresentExceptionMessage = "Value cannot be null. (Parameter 'Present is null')";
        private const string ExistingPresentExceptionMessage = "This present already exists!";
        private const string SuccessfullyAddedPresentOutputMessage = "Successfully added present {0}.";

        private readonly Present present1 = new Present("Present1", 10.1);
        private readonly Present present2 = new Present("Present2", 12.1);
        private readonly Present present3 = new Present("Present3", 13.1);

        private Bag bag;

        [SetUp]
        public void Initialization()
        {
            this.bag = new Bag();
        }

        [Test]
        public void PresentsConstructorWorksCorrectly()
        {
            Assert.AreEqual("Present1", this.present1.Name);
            Assert.AreEqual(10.1, this.present1.Magic);
        }

        [Test]
        public void BagInitializationWithEmptyCollection()
        {
            Assert.AreEqual(0, this.bag.GetPresents().Count);
        }

        [Test]
        public void GetPresetsReturnsCorrectly()
        {
            this.bag.Create(this.present1);
            this.bag.Create(this.present2);

            Assert.AreEqual(2, this.bag.GetPresents().Count);
            Assert.AreEqual(present1, this.bag.GetPresents().First());
            Assert.AreEqual(present2, this.bag.GetPresents().Last());
        }

        [Test]
        public void CreateAddsPresentToBagAndReturnsOutputMessage()
        {
            string outputMessge1 = this.bag.Create(this.present1);
            string outputMessge2 = this.bag.Create(this.present2);
            string outputMessge3 = this.bag.Create(this.present3);

            Assert.AreEqual(3, this.bag.GetPresents().Count);
            Assert.AreEqual(string.Format(SuccessfullyAddedPresentOutputMessage, present1.Name), outputMessge1);
            Assert.AreEqual(string.Format(SuccessfullyAddedPresentOutputMessage, present2.Name), outputMessge2);
            Assert.AreEqual(string.Format(SuccessfullyAddedPresentOutputMessage, present3.Name), outputMessge3);
        }

        [Test]
        public void CreateThrowsIfNull()
        {
            Assert.That(() => this.bag.Create(null), Throws.ArgumentNullException.With.Message.EqualTo(NullPresentExceptionMessage));
        }

        [Test]
        public void CreateThrowsIfPresentExists()
        {
            this.bag.Create(this.present1);
            this.bag.Create(this.present2);

            Assert.That(() => this.bag.Create(this.present1), Throws.InvalidOperationException.With.Message.EqualTo(ExistingPresentExceptionMessage));
        }

        [Test]
        public void RemoveRemovesGivenPresent()
        {
            this.bag.Create(this.present1);
            this.bag.Create(this.present2);
            this.bag.Create(this.present3);

            bool isRemoved = this.bag.Remove(this.present1);

            Assert.IsTrue(isRemoved);
            Assert.AreEqual(2, this.bag.GetPresents().Count);
            Assert.IsFalse(this.bag.GetPresents().Contains(present1));
        }

        [Test]
        public void RemoveNotRemovesInexistantPresent()
        {
            this.bag.Create(this.present1);
            this.bag.Create(this.present2);

            bool isRemoved = this.bag.Remove(this.present3);

            Assert.IsFalse(isRemoved);
            Assert.AreEqual(2, this.bag.GetPresents().Count);
        }

        [Test]
        public void GetPresentWithLeastMagicWorksCorrectly()
        {
            this.bag.Create(this.present1);
            this.bag.Create(this.present2);
            this.bag.Create(this.present3);

            Present present = this.bag.GetPresentWithLeastMagic();

            Assert.AreEqual(present1, present);
        }

        [Test]
        public void GetPresentWithLeastMagicThrowsIfEmptyCollection()
        {
            Assert.That(() => this.bag.GetPresentWithLeastMagic(), Throws.InvalidOperationException);
        }

        [Test]
        public void GetPresentWorksCorrectly()
        {
            this.bag.Create(this.present1);
            this.bag.Create(this.present2);
            this.bag.Create(this.present3);

            Present present = this.bag.GetPresent(this.present1.Name);

            Assert.AreEqual(present1, present);
        }

        [Test]
        public void GetPresentReturnsNullIfEmptyCollection()
        {
            Present present = this.bag.GetPresent(this.present1.Name);

            Assert.AreEqual(null, present);
        }

        [Test]
        public void GetPresentReturnsNullIfPresentNotExists()
        {
            this.bag.Create(this.present1);
            this.bag.Create(this.present2);

            Present present = this.bag.GetPresent(this.present3.Name);

            Assert.AreEqual(null, present);
        }
    }
}

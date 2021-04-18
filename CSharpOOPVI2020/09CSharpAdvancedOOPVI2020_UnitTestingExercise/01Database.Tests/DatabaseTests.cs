using _01Database;//For Judge must be commented: using _01Database; and <ProjectReference Include="..\01Database\01Database.csproj" /> in 01Database.Tests.csproj file
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private const int FullCapacityCount = 16;
        private const int HalfCapacityCount = 8;
        private const int EmptyDatabaseCount = 0;
        private const int AlmostFullCapacityCount = 15;
        private const string EmptyArrayExceptionMessage = "The collection is empty!";
        private const string FullCapacityExceptionMessage = "Array's capacity must be exactly 16 integers!";

        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
        }

        [Test]
        public void DatabaseInitialisationWith16Integers()
        {
            Assert.That(this.database.Count, Is.EqualTo(FullCapacityCount));
        }

        [Test]
        public void DatabaseInitialisationWith8Integers()
        {
            this.database = new Database(1, 2, 3, 4, 5, 6, 7, 8);

            Assert.That(this.database.Count, Is.EqualTo(HalfCapacityCount));
        }

        [Test]
        public void DatabaseInitialisationWith0Integers()
        {
            this.database = new Database();

            Assert.That(this.database.Count, Is.EqualTo(EmptyDatabaseCount));
        }

        [Test]
        public void DatabaseInitialisationWith17IntegersThrowsInvalidOperationException()
        {
            Assert.That(() => this.database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveRemovesTheLastElement()
        {
            this.database.Remove();

            Assert.That(this.database.Count, Is.EqualTo(AlmostFullCapacityCount));
        }

        [Test]
        public void RemoveThrowsWhenCountIs0()
        {
            for (int i = 0; i < FullCapacityCount; i++)
            {
                this.database.Remove();
            }            

            Assert.That(() => this.database.Remove(), Throws.InvalidOperationException.With.Message.EqualTo(EmptyArrayExceptionMessage));
        }

        [Test]
        public void AddAddsLastElement()
        {
            this.database.Remove();
            this.database.Add(17);            

            Assert.That(this.database.Count, Is.EqualTo(FullCapacityCount));
        }

        [Test]
        public void AddThrowsIfFullCapacity()
        {
            Assert.That(() => this.database.Add(17), Throws.InvalidOperationException.With.Message.EqualTo(FullCapacityExceptionMessage));
        }

        [Test]
        public void FetchReturnsDatabaseCountElements()
        {
            for (int i = 0; i < HalfCapacityCount; i++)
            {
                this.database.Remove();
            }

            int[] fetched = this.database.Fetch();

            Assert.That(fetched.Length, Is.EqualTo(HalfCapacityCount));

            for (int i = 1; i <= HalfCapacityCount; i++)
            {
                Assert.That(fetched[i - 1], Is.EqualTo(i));
            }
        }
    }
}
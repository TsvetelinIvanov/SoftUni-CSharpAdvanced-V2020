using _02ExtendedDatabase;//For Judge must be commented: using _02ExtendedDatabase; and <ProjectReference Include="..\02ExtendedDatabase\02ExtendedDatabase.csproj" /> in 02ExtendedDatabase.Tests.csproj file
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private const int FullCapacityCount = 16;
        private const int HalfCapacityCount = 8;
        private const int EmptyDatabaseCount = 0;
        private const int AlmostFullCapacityCount = 15;
        private const int ExpectedPersonId = 1;
        private const int NonExistingPersonId = 18;
        private const string ExpectedPersonUsername = "User1";
        private const string NonExistingPersonUsername = "User18";
        private const string RangeCapacityExceptionMessage = "Provided data length should be in range [0..16]!";
        private const string FullCapacityExceptionMessage = "Array's capacity must be exactly 16 integers!";
        private const string ExistingUsernameExceptionMessage = "There is already user with this username!";
        private const string ExistingIdExceptionMessage = "There is already user with this Id!";
        private const string NullUsernameExceptionMessage = "Username parameter is null!";
        private const string NonExistingUsernameExceptionMessage = "No user is present by this username!";        
        private const string NegativeIdExceptionMessage = "Id should be a positive number!";
        private const string NonExistingIdExceptionMessage = "No user is present by this ID!";

        private ExtendedDatabase extendedDatabase;

        [SetUp]
        public void Setup()
        {
            this.extendedDatabase = new ExtendedDatabase(new Person(1, "User1"), new Person(2, "User2"), new Person(3, "User3"), new Person(4, "User4"), new Person(5, "User5"), new Person(6, "User6"), new Person(7, "User7"), new Person(8, "User8"), new Person(9, "User9"), new Person(10, "User10"), new Person(11, "User11"), new Person(12, "User12"), new Person(13, "User13"), new Person(14, "User14"), new Person(15, "User15"), new Person(16, "User16"));
        }

        [Test]
        public void DatabaseInitialisationWith16Persons()
        {
            Assert.That(this.extendedDatabase.Count, Is.EqualTo(FullCapacityCount));
        }

        [Test]
        public void DatabaseInitialisationWith8Persons()
        {
            this.extendedDatabase = new ExtendedDatabase(new Person(1, "User1"), new Person(2, "User2"), new Person(3, "User3"), new Person(4, "User4"), new Person(5, "User5"), new Person(6, "User6"), new Person(7, "User7"), new Person(8, "User8"));

            Assert.That(this.extendedDatabase.Count, Is.EqualTo(HalfCapacityCount));         
        }

        [Test]
        public void DatabaseInitialisationWith0Persons()
        {
            this.extendedDatabase = new ExtendedDatabase();

            Assert.That(this.extendedDatabase.Count, Is.EqualTo(EmptyDatabaseCount));
        }        

        [Test]
        public void DatabaseInitialisationWith17PersonsThrowsException()
        {
            Assert.That(() => this.extendedDatabase = new ExtendedDatabase(new Person(1, "User1"), new Person(2, "User2"), new Person(3, "User3"), new Person(4, "User4"), new Person(5, "User5"), new Person(6, "User6"), new Person(7, "User7"), new Person(8, "User8"), new Person(9, "User9"), new Person(10, "User10"), new Person(11, "User11"), new Person(12, "User12"), new Person(13, "User13"), new Person(14, "User14"), new Person(15, "User15"), new Person(16, "User16"), new Person(17, "User17")), Throws.ArgumentException.With.Message.EqualTo(RangeCapacityExceptionMessage));
        }

        [Test]
        public void RemoveRemovesTheLastElement()
        {
            this.extendedDatabase.Remove();

            Assert.That(this.extendedDatabase.Count, Is.EqualTo(AlmostFullCapacityCount));
        }

        [Test]
        public void RemoveThrowsWhenCountIs0()
        {
            for (int i = 0; i < FullCapacityCount; i++)
            {
                this.extendedDatabase.Remove();
            }

            Assert.That(() => this.extendedDatabase.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void AddAddsLastElement()
        {
            this.extendedDatabase.Remove();
            this.extendedDatabase.Add(new Person(17, "User17"));

            Assert.That(this.extendedDatabase.Count, Is.EqualTo(FullCapacityCount));
        }

        [Test]
        public void AddThrowsIfFullCapacity()
        {
            Assert.That(() => this.extendedDatabase.Add(new Person(17, "User17")), Throws.InvalidOperationException.With.Message.EqualTo(FullCapacityExceptionMessage));
        }

        [Test]
        public void AddThrowsIfExitingUsername()
        {
            this.extendedDatabase.Remove();

            Assert.That(() => this.extendedDatabase.Add(new Person(17, "User1")), Throws.InvalidOperationException.With.Message.EqualTo(ExistingUsernameExceptionMessage));
        }

        [Test]
        public void AddThrowsIfExistingId()
        {
            this.extendedDatabase.Remove();

            Assert.That(() => this.extendedDatabase.Add(new Person(1, "User17")), Throws.InvalidOperationException.With.Message.EqualTo(ExistingIdExceptionMessage));
        }

        [Test]
        public void FindByUsernameReturnsPerson()
        {
            Person person = this.extendedDatabase.FindByUsername(ExpectedPersonUsername);

            Assert.AreEqual(ExpectedPersonId, person.Id);
            Assert.AreEqual(ExpectedPersonUsername, person.UserName);
        }

        [Test]
        public void FindByUsernameThrowsIfNull()
        {
            Assert.That(() => this.extendedDatabase.FindByUsername(null), Throws.ArgumentNullException);
        }

        [Test]
        public void FindByUsernameThrowsIfNonExistingUsername()
        {
            Assert.That(() => this.extendedDatabase.FindByUsername(NonExistingPersonUsername), Throws.InvalidOperationException.With.Message.EqualTo(NonExistingUsernameExceptionMessage));
        }

        [Test]
        public void FindByIdReturnsPerson()
        {
            Person person = this.extendedDatabase.FindById(ExpectedPersonId);

            Assert.AreEqual(ExpectedPersonId, person.Id);
            Assert.AreEqual(ExpectedPersonUsername, person.UserName);
        }

        [Test]
        public void FindByIdThrowsIfNegative()
        {
            try
            {
                Person person = this.extendedDatabase.FindById(-1);
            }
            catch (System.ArgumentOutOfRangeException auore)
            {
                Assert.That(auore.ParamName, Is.EqualTo(NegativeIdExceptionMessage));    
            }          
        }

        [Test]
        public void FindByIdThrowsIfNonExistingId()
        {
            Assert.That(() => this.extendedDatabase.FindById(NonExistingPersonId), Throws.InvalidOperationException.With.Message.EqualTo(NonExistingIdExceptionMessage));
        }
    }
}
using Chainblock.Contracts;
using Chainblock.Models;
using NUnit.Framework;

namespace Chainblock.Tests
{
    public class TransactionTests
    {
        private const int Id = 1;
        private const string Sender = "Sender";
        private const string Receiver = "Receiver";
        private double Amount = 10.50;
        private const string InvalidIdExceptionMessage = "The id can not be negative!";
        private const string InvalidSenderExceptionMessage = "The sender can not be blank!";
        private const string InvalidReceiverExceptionMessage = "The receiver can not be blank!";
        private const string InvalidAmountExceptionMessage = "The amount must be greater than 0!";

        private readonly TransactionStatus Status = TransactionStatus.Successfull;

        private ITransaction transaction;        
        private ITransaction blankTransaction;

        [SetUp]
        public void Initialization()
        {
            this.transaction = new Transaction(Id, Status, Sender, Receiver, Amount);
            this.blankTransaction = new Transaction();
        }

        [Test]
        public void SetIdWorksCorrectly()
        {
            this.blankTransaction.Id = Id;

            Assert.AreEqual(Id, this.transaction.Id);
            Assert.AreEqual(Id, this.blankTransaction.Id);
        }

        [Test]
        public void SetStatusWorksCorrectly()
        {
            this.blankTransaction.Status = Status;

            Assert.AreEqual(Status, this.transaction.Status);
            Assert.AreEqual(Status, this.blankTransaction.Status);
        }

        [Test]
        public void SetFromWorksCorrectly()
        {
            this.blankTransaction.From = Sender;

            Assert.AreEqual(Sender, this.transaction.From);
            Assert.AreEqual(Sender, this.blankTransaction.From);
        }

        [Test]
        public void SetToWorksCorrectly()
        {
            this.blankTransaction.To = Receiver;

            Assert.AreEqual(Receiver, this.transaction.To);
            Assert.AreEqual(Receiver, this.blankTransaction.To);
        }

        [Test]
        public void SetAmountWorksCorrectly()
        {
            this.blankTransaction.Amount = Amount;

            Assert.AreEqual(Amount, this.transaction.Amount);
            Assert.AreEqual(Amount, this.blankTransaction.Amount);
        }

        [Test]
        public void SetInvalidIdThrows()
        {
            Assert.That(() => this.transaction = new Transaction(-1, Status, Sender, Receiver, Amount), Throws.ArgumentException.With.Message.EqualTo(InvalidIdExceptionMessage));
            Assert.That(() => this.blankTransaction.Id = -1, Throws.ArgumentException.With.Message.EqualTo(InvalidIdExceptionMessage));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void SetInvalidSenderThrows(string invalidSender)
        {
            Assert.That(() => this.transaction = new Transaction(Id, Status, invalidSender, Receiver, Amount), Throws.ArgumentException.With.Message.EqualTo(InvalidSenderExceptionMessage));
            Assert.That(() => this.blankTransaction.From = invalidSender, Throws.ArgumentException.With.Message.EqualTo(InvalidSenderExceptionMessage));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void SetInvalidReceiverThrows(string invalidReceiver)
        {
            Assert.That(() => this.transaction = new Transaction(Id, Status, Sender, invalidReceiver, Amount), Throws.ArgumentException.With.Message.EqualTo(InvalidReceiverExceptionMessage));
            Assert.That(() => this.blankTransaction.To = invalidReceiver, Throws.ArgumentException.With.Message.EqualTo(InvalidReceiverExceptionMessage));
        }

        [TestCase(0)]
        [TestCase(-1)]        
        public void SetInvalidAmountThrows(double invalidAmount)
        {
            Assert.That(() => this.transaction = new Transaction(Id, Status, Sender, Receiver, invalidAmount), Throws.ArgumentException.With.Message.EqualTo(InvalidAmountExceptionMessage));
            Assert.That(() => this.blankTransaction.Amount = invalidAmount, Throws.ArgumentException.With.Message.EqualTo(InvalidAmountExceptionMessage));
        }
    }
}
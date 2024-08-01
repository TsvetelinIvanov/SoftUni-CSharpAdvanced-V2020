using System;
using System.Linq;
using Chainblock.Contracts;
using Chainblock.Models;
using Moq;
using NUnit.Framework;


namespace Chainblock.Tests//The real objects transaction1 and transaction2 are used only by testing ChangeTransactionStatus method
{
    public class ChainblockTests
    {
        private const string ExistingTransactionExceptionMessage = "This transaction was added!";
        private const string NonExistentIdExceptionMessage = "There is no transaction with id: {0}!";
        private const string NonExistentStatusExceptionMessage = "There are no transactions with status: {0}!";
        private const string NonExistentSenderExceptionMessage = "There are no transactions from: {0}!";
        private const string NonExistentReceiverExceptionMessage = "There are no transactions to: {0}!";
        private const string NonExistentSenderAndMinAmountExceptionMessage = "There are no transactions from: {0} with amount equal to or bigger than: {1}!";
        private const string NonExistentReceiverAndAmountRangeExceptionMessage = "There are no transactions to: {0} between {1} (inclusive) and {2} (exclusive)!";
        private const string InvanidAmountExceptionMessage = "The amount must be greater than 0!";

        private readonly ITransaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "TransactionUser1", "TransactionUser2", 10.5);
        private readonly ITransaction transaction2 = new Transaction(2, TransactionStatus.Failed, "TransactionUser1", "TransactionUser3", 12.5);
        //private readonly ITransaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "TransactionUser2", "TransactionUser3", 100);
        //private readonly ITransaction transaction4 = new Transaction(4, TransactionStatus.Successfull, "TransactionUser1", "TransactionUser3", 6.7);

        private IChainblock chainblock;
        private Mock<ITransaction> fackeTransaction1;
        private Mock<ITransaction> fackeTransaction2;
        private Mock<ITransaction> fackeTransaction3;
        private Mock<ITransaction> fackeTransaction4;        

        [SetUp]
        public void Inicialization()
        {
            this.chainblock = new Chainblock.Models.Chainblock();
            
            this.fackeTransaction1 = new Mock<ITransaction>();
            fackeTransaction1.Setup(t => t.Id).Returns(1);
            fackeTransaction1.Setup(t => t.Status).Returns(TransactionStatus.Successfull);
            fackeTransaction1.Setup(t => t.From).Returns("FakeTransactionUser1");
            fackeTransaction1.Setup(t => t.To).Returns("FakeTransactionUser2");
            fackeTransaction1.Setup(t => t.Amount).Returns(10.5);
            
            this.fackeTransaction2 = new Mock<ITransaction>();
            fackeTransaction2.Setup(t => t.Id).Returns(2);
            fackeTransaction2.Setup(t => t.Status).Returns(TransactionStatus.Failed);
            fackeTransaction2.Setup(t => t.From).Returns("FakeTransactionUser1");
            fackeTransaction2.Setup(t => t.To).Returns("FakeTransactionUser3");
            fackeTransaction2.Setup(t => t.Amount).Returns(12.5);
            
            this.fackeTransaction3 = new Mock<ITransaction>();
            fackeTransaction3.Setup(t => t.Id).Returns(3);
            fackeTransaction3.Setup(t => t.Status).Returns(TransactionStatus.Successfull);
            fackeTransaction3.Setup(t => t.From).Returns("FakeTransactionUser2");
            fackeTransaction3.Setup(t => t.To).Returns("FakeTransactionUser3");
            fackeTransaction3.Setup(t => t.Amount).Returns(100);
            
            this.fackeTransaction4 = new Mock<ITransaction>();
            fackeTransaction4.Setup(t => t.Id).Returns(4);
            fackeTransaction4.Setup(t => t.Status).Returns(TransactionStatus.Successfull);
            fackeTransaction4.Setup(t => t.From).Returns("FakeTransactionUser1");
            fackeTransaction4.Setup(t => t.To).Returns("FakeTransactionUser3");
            fackeTransaction4.Setup(t => t.Amount).Returns(6.7);            
        }

        [Test]
        public void InitializationWithEmptyCollection()
        {
            Assert.AreEqual(0, this.chainblock.Count);
        }

        [Test]
        public void AddAddsGivenTransactions()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);
            this.chainblock.Add(fackeTransaction3.Object);
            this.chainblock.Add(fackeTransaction4.Object);

            Assert.AreEqual(4, this.chainblock.Count);            
        }

        [Test]
        public void AddNullThrows()
        {
            Assert.That(() => this.chainblock.Add(null), Throws.ArgumentNullException);
        }

        [Test]
        public void AddExistingTransactionThrows()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);

            Assert.That(() => this.chainblock.Add(fackeTransaction1.Object), Throws.ArgumentException.With.Message.EqualTo(ExistingTransactionExceptionMessage));
        }

        [Test]
        public void ContainsTransactionReturnsTrueIfExists()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);

            Assert.IsTrue(this.chainblock.Contains(fackeTransaction1.Object));
        }

        [Test]
        public void ContainsTransactionReturnsFalseIfNotExists()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);

            Assert.IsFalse(this.chainblock.Contains(fackeTransaction3.Object));
        }

        [Test]
        public void ContainsTransactionByIdReturnsTrueIfExists()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);

            Assert.IsTrue(this.chainblock.Contains(1));
        }

        [Test]
        public void ContainsTransactionByIdReturnsFalseIfNotExists()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);

            Assert.IsFalse(this.chainblock.Contains(3));
        }

        [Test]
        public void RemoveTransactionByIdRemovesIfExists()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);

            this.chainblock.RemoveTransactionById(1);

            Assert.AreEqual(1, this.chainblock.Count);
            Assert.IsFalse(this.chainblock.Contains(1));
        }

        [Test]
        public void RemoveTransactionByIdThrowsIfNotExists()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);

            Assert.That(() => this.chainblock.RemoveTransactionById(3), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(NonExistentIdExceptionMessage, 3)));
        }

        [Test]
        public void GetByIdReturnsIfExists()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);

            ITransaction transaction = this.chainblock.GetById(1);

            Assert.AreEqual(fackeTransaction1.Object, transaction);            
        }

        [Test]
        public void GetByIdThrowsIfNotExists()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);

            Assert.That(() => this.chainblock.GetById(3), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(NonExistentIdExceptionMessage, 3)));
        }

        [Test]
        public void ChangeTransactionStatusWorksCorrectly()
        {
            this.chainblock.Add(this.transaction1);
            this.chainblock.Add(this.transaction2);

            this.chainblock.ChangeTransactionStatus(2, TransactionStatus.Successfull);

            Assert.AreEqual(TransactionStatus.Successfull, this.transaction2.Status);
        }

        [Test]
        public void ChangeTransactionStatusThrowsIfNotExists()
        {
            this.chainblock.Add(this.transaction1);
            this.chainblock.Add(this.transaction2);

            this.chainblock.ChangeTransactionStatus(2, TransactionStatus.Successfull);

            Assert.That(() => this.chainblock.ChangeTransactionStatus(3, TransactionStatus.Successfull), Throws.ArgumentException.With.Message.EqualTo(string.Format(NonExistentIdExceptionMessage, 3)));
        }

        [Test]
        public void GetByTransactionStatusWorksCorrectly()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);
            this.chainblock.Add(fackeTransaction3.Object);
            this.chainblock.Add(fackeTransaction4.Object);

            ITransaction[] transactionsWithGivenStatus = this.chainblock.GetByTransactionStatus(TransactionStatus.Successfull).ToArray();

            Assert.AreEqual(3, transactionsWithGivenStatus.Length);
            Assert.AreEqual(100, transactionsWithGivenStatus[0].Amount);
            Assert.AreEqual(10.5, transactionsWithGivenStatus[1].Amount);
            Assert.AreEqual(6.7, transactionsWithGivenStatus[2].Amount);
        }

        [Test]
        public void GetByTransactionStatusThrowsIfNotExists()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);          

            Assert.That(() => this.chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(NonExistentStatusExceptionMessage, TransactionStatus.Unauthorized)));       
        }

        [Test]
        public void GetAllSendersWithTransactionStatusWorksCorrectly()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);
            this.chainblock.Add(fackeTransaction3.Object);
            this.chainblock.Add(fackeTransaction4.Object);

            string[] sendersWithGivenStatus = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull).ToArray();

            Assert.AreEqual(3, sendersWithGivenStatus.Length);
            Assert.AreEqual("FakeTransactionUser2", sendersWithGivenStatus[0]);
            Assert.AreEqual("FakeTransactionUser1", sendersWithGivenStatus[1]);
            Assert.AreEqual("FakeTransactionUser1", sendersWithGivenStatus[2]);
        }

        [Test]
        public void GetAllSendersWithTransactionStatusThrowsIfNotExists()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);           

            Assert.That(() => this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(NonExistentStatusExceptionMessage, TransactionStatus.Unauthorized)));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusWorksCorrectly()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);
            this.chainblock.Add(fackeTransaction3.Object);
            this.chainblock.Add(fackeTransaction4.Object);

            string[] receiversWithGivenStatus = this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull).ToArray();

            Assert.AreEqual(3, receiversWithGivenStatus.Length);
            Assert.AreEqual("FakeTransactionUser3", receiversWithGivenStatus[0]);
            Assert.AreEqual("FakeTransactionUser2", receiversWithGivenStatus[1]);
            Assert.AreEqual("FakeTransactionUser3", receiversWithGivenStatus[2]);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusThrowsIfNotExists()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);

            Assert.That(() => this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Unauthorized), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(NonExistentStatusExceptionMessage, TransactionStatus.Unauthorized)));
        }

        [Test]
        public void GetAllInAmountRangeReturnsTransactionsWithAmountInGivenRange()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);
            this.chainblock.Add(fackeTransaction3.Object);
            this.chainblock.Add(fackeTransaction4.Object);

            ITransaction[] transactionsInGivenRange = this.chainblock.GetAllInAmountRange(10.5, 13).ToArray();

            Assert.AreEqual(2, transactionsInGivenRange.Length);
            Assert.AreEqual(10.5, transactionsInGivenRange[0].Amount);
            Assert.AreEqual(12.5, transactionsInGivenRange[1].Amount);            
        }

        [Test]
        public void GetAllInAmountRangeReturnsEmptyCollectionIfNotingInRange()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);            

            ITransaction[] transactionsInGivenRange = this.chainblock.GetAllInAmountRange(15, 17.7).ToArray();

            Assert.AreEqual(0, transactionsInGivenRange.Length);            
        }

        [TestCase(0, 14)]
        [TestCase(14, 0)]
        [TestCase(-1, 14)]
        [TestCase(14, -1)]
        public void GetAllInAmountRangeThrowsIf0OrLess(double low, double high)
        {
            Assert.That(() => this.chainblock.GetAllInAmountRange(low, high), Throws.ArgumentException.With.Message.EqualTo(InvanidAmountExceptionMessage));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountWorksCorrectly()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);
            this.chainblock.Add(fackeTransaction3.Object);
            this.chainblock.Add(fackeTransaction4.Object);

            ITransaction[] transactionsWithGivenStatusAndMaxAmount = this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 10.5).ToArray();

            Assert.AreEqual(2, transactionsWithGivenStatusAndMaxAmount.Length);
            Assert.AreEqual(10.5, transactionsWithGivenStatusAndMaxAmount[0].Amount);
            Assert.AreEqual(6.7, transactionsWithGivenStatusAndMaxAmount[1].Amount);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountReturnsEmptyCollectionIfNotExists()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);

            ITransaction[] transactionsInGivenRange = this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 1.7).ToArray();

            Assert.AreEqual(0, transactionsInGivenRange.Length);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdWorksCorrectly()
        {
            this.fackeTransaction4.Setup(t => t.Amount).Returns(10.5);

            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);
            this.chainblock.Add(fackeTransaction3.Object);
            this.chainblock.Add(fackeTransaction4.Object);

            ITransaction[] transactionsOrderedByAmountAndId = this.chainblock.GetAllOrderedByAmountDescendingThenById().ToArray();
            
            Assert.AreEqual(3, transactionsOrderedByAmountAndId[0].Id);
            Assert.AreEqual(2, transactionsOrderedByAmountAndId[1].Id);
            Assert.AreEqual(1, transactionsOrderedByAmountAndId[2].Id);
            Assert.AreEqual(4, transactionsOrderedByAmountAndId[3].Id);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdReturnsEmptyCollectionIfNotExists()
        {            
            ITransaction[] transactionsOrderedByAmountAndId = this.chainblock.GetAllOrderedByAmountDescendingThenById().ToArray();

            Assert.AreEqual(0, transactionsOrderedByAmountAndId.Length);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingWorksCorrectly()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);
            this.chainblock.Add(fackeTransaction3.Object);
            this.chainblock.Add(fackeTransaction4.Object);

            ITransaction[] transactionsByGivenSender = this.chainblock.GetBySenderOrderedByAmountDescending("FakeTransactionUser1").ToArray();

            Assert.AreEqual(3, transactionsByGivenSender.Length);
            Assert.AreEqual(12.5, transactionsByGivenSender[0].Amount);
            Assert.AreEqual(10.5, transactionsByGivenSender[1].Amount);
            Assert.AreEqual(6.7, transactionsByGivenSender[2].Amount);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingThrowsIfNoSender()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);

            Assert.That(() => this.chainblock.GetBySenderOrderedByAmountDescending("FakeTransactionUser3"), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(NonExistentSenderExceptionMessage, "FakeTransactionUser3")));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdWorksCorrectly()
        {
            this.fackeTransaction4.Setup(t => t.Amount).Returns(12.5);

            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);
            this.chainblock.Add(fackeTransaction3.Object);
            this.chainblock.Add(fackeTransaction4.Object);

            ITransaction[] transactionsByGivenReceiver = this.chainblock.GetByReceiverOrderedByAmountThenById("FakeTransactionUser3").ToArray();

            Assert.AreEqual(3, transactionsByGivenReceiver.Length);
            Assert.AreEqual(3, transactionsByGivenReceiver[0].Id);
            Assert.AreEqual(2, transactionsByGivenReceiver[1].Id);
            Assert.AreEqual(4, transactionsByGivenReceiver[2].Id);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdThrowsIfNoReceiver()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);

            Assert.That(() => this.chainblock.GetByReceiverOrderedByAmountThenById("FakeTransactionUser1"), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(NonExistentReceiverExceptionMessage, "FakeTransactionUser1")));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingWorksCorrectly()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);
            this.chainblock.Add(fackeTransaction3.Object);
            this.chainblock.Add(fackeTransaction4.Object);

            ITransaction[] transactionsByGivenSender = this.chainblock.GetBySenderAndMinimumAmountDescending("FakeTransactionUser1", 10.5).ToArray();

            Assert.AreEqual(2, transactionsByGivenSender.Length);
            Assert.AreEqual(12.5, transactionsByGivenSender[0].Amount);
            Assert.AreEqual(10.5, transactionsByGivenSender[1].Amount);            
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingThrowsIfNoSenderAndAmount()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);

            Assert.That(() => this.chainblock.GetBySenderAndMinimumAmountDescending("FakeTransactionUser1", 100), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(NonExistentSenderAndMinAmountExceptionMessage, "FakeTransactionUser1", 100)));
        }

        [Test]
        public void GetByReceiverAndAmountRangeWorksCorrectly()
        {
            this.fackeTransaction4.Setup(t => t.Amount).Returns(12.5);

            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);
            this.chainblock.Add(fackeTransaction3.Object);
            this.chainblock.Add(fackeTransaction4.Object);

            ITransaction[] transactionsByGivenReceiver = this.chainblock.GetByReceiverAndAmountRange("FakeTransactionUser3", 12.5, 100).ToArray();

            Assert.AreEqual(2, transactionsByGivenReceiver.Length);            
            Assert.AreEqual(2, transactionsByGivenReceiver[0].Id);
            Assert.AreEqual(4, transactionsByGivenReceiver[1].Id);
        }

        [TestCase(0, 14)]
        [TestCase(14, 0)]
        [TestCase(-1, 14)]
        [TestCase(14, -1)]
        public void GetByReceiverAndAmountRangeIf0OrLess(double low, double high)
        {
            Assert.That(() => this.chainblock.GetByReceiverAndAmountRange("FakeTransactionUser3", low, high), Throws.ArgumentException.With.Message.EqualTo(InvanidAmountExceptionMessage));
        }

        [Test]
        public void GetByReceiverAndAmountRangeThrowsIfNoReceiver()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);

            Assert.That(() => this.chainblock.GetByReceiverAndAmountRange("FakeTransactionUser3", 15, 100), Throws.InvalidOperationException.With.Message.EqualTo(string.Format(NonExistentReceiverAndAmountRangeExceptionMessage, "FakeTransactionUser3", 15, 100)));
        }

        [Test]
        public void GetEnumeratorWorksCorrectly()
        {
            this.chainblock.Add(fackeTransaction1.Object);
            this.chainblock.Add(fackeTransaction2.Object);
            this.chainblock.Add(fackeTransaction3.Object);
            this.chainblock.Add(fackeTransaction4.Object);

            int index = 1;
            foreach (int id in this.chainblock.Select(t => t.Id))
            {
                Assert.AreEqual(index, id);
                index++;
            }
        }
    }
}

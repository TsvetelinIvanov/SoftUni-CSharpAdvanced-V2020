using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock.Models
{
    public class Chainblock : IChainblock
    {
        private List<ITransaction> transactions;

        public Chainblock()
        {
            this.transactions = new List<ITransaction>();
        }

        public int Count => this.transactions.Count;

        public void Add(ITransaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException();
            }

            if (this.Contains(transaction))
            {
                throw new ArgumentException("This transaction was added!");
            }

            this.transactions.Add(transaction);
        }        

        public bool Contains(ITransaction transaction)
        {
            return this.transactions.Contains(transaction);
        }

        public bool Contains(int id)
        {
            return this.transactions.Any(t => t.Id == id);
        }

        public void RemoveTransactionById(int id)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                throw new InvalidOperationException($"There is no transaction with id: {id}!");
            }

            this.transactions.Remove(transaction);
        }

        public ITransaction GetById(int id)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                throw new InvalidOperationException($"There is no transaction with id: {id}!");
            }

            return transaction;
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                throw new ArgumentException($"There is no transaction with id: {id}!");
            }

            transaction.Status = newStatus;
        }        

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IOrderedEnumerable<ITransaction> transactionsWithGivenStatus = this.transactions.Where(t => t.Status == status).OrderByDescending(t => t.Amount);
            if (transactionsWithGivenStatus.Count() == 0)
            {
                throw new InvalidOperationException($"There are no transactions with status: {status}!");
            }

            return transactionsWithGivenStatus;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> sendersWithGivenStatus = this.transactions.Where(t => t.Status == status).OrderByDescending(t => t.Amount).Select(t => t.From);
            if (sendersWithGivenStatus.Count() == 0)
            {
                throw new InvalidOperationException($"There are no transactions with status: {status}!");
            }

            return sendersWithGivenStatus;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> receiversWithGivenStatus = this.transactions.Where(t => t.Status == status).OrderByDescending(t => t.Amount).Select(t => t.To);
            if (receiversWithGivenStatus.Count() == 0)
            {
                throw new InvalidOperationException($"There are no transactions with status: {status}!");
            }

            return receiversWithGivenStatus;
        }        

        public IEnumerable<ITransaction> GetAllInAmountRange(double low, double high)
        {
            if (low <= 0 || high <= 0)
            {
                throw new ArgumentException("The amount must be greater than 0!");
            }

            return this.transactions.Where(t => t.Amount >= low && t.Amount <= high);
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            return this.transactions.Where(t => t.Status == status && t.Amount <= amount).OrderByDescending(p => p.Amount);
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactions.OrderByDescending(t => t.Amount).ThenBy(t => t.Id);
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IOrderedEnumerable<ITransaction> transactionsByGivenSender = this.transactions.Where(t => t.From == sender).OrderByDescending(t => t.Amount);
            if (transactionsByGivenSender.Count() == 0)
            {
                throw new InvalidOperationException($"There are no transactions from: {sender}!");
            }

            return transactionsByGivenSender;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            IOrderedEnumerable<ITransaction> transactionsByGivenReceiver = this.transactions.Where(t => t.To == receiver).OrderByDescending(t => t.Amount).ThenBy(t => t.Id);
            if (transactionsByGivenReceiver.Count() == 0)
            {
                throw new InvalidOperationException($"There are no transactions to: {receiver}!");
            }

            return transactionsByGivenReceiver;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            IOrderedEnumerable<ITransaction> transactionsByGivenSender = this.transactions.Where(t => t.From == sender && t.Amount >= amount).OrderByDescending(t => t.Amount);
            if (transactionsByGivenSender.Count() == 0)
            {
                throw new InvalidOperationException($"There are no transactions from: {sender} with amount equal to or bigger than: {amount}!");
            }

            return transactionsByGivenSender;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double low, double high)
        {
            if (low <= 0 || high <= 0)
            {
                throw new ArgumentException("The amount must be greater than 0!");
            }

            IOrderedEnumerable<ITransaction> transactionsByGivenReceiver = this.transactions.Where(t => t.To == receiver && t.Amount >= low && t.Amount < high).OrderByDescending(t => t.Amount).ThenBy(t => t.Id);
            if (transactionsByGivenReceiver.Count() == 0)
            {
                throw new InvalidOperationException($"There are no transactions to: {receiver} between {low} (inclusive) and {high} (exclusive)!");
            }

            return transactionsByGivenReceiver;
        }        

        public IEnumerator<ITransaction> GetEnumerator()
        {
            for (int i = 0; i < this.transactions.Count; i++)
            {
                yield return this.transactions[i];
            }
        }        

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
using Chainblock.Contracts;
using System;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private int id;
        private string from;
        private string to;
        private double amount;

        public Transaction()
        {

        }

        public Transaction(int id, TransactionStatus status, string from, string to, double amount)
        {
            this.Id = id;
            this.Status = status;
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The id can not be negative!");
                }

                this.id = value;
            }
        }
        
        public TransactionStatus Status { get; set; }
        
        public string From
        {
            get { return this.from; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The sender can not be blank!");
                }

                this.from = value;
            }
        }
        public string To
        {
            get { return this.to; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The receiver can not be blank!");
                }

                this.to = value;
            }
        }
        public double Amount
        {
            get { return this.amount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The amount must be greater than 0!");
                }

                this.amount = value;
            }
        }
    }
}

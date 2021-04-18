using INStock.Contracts;
using System;

namespace INStock.Models
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;

        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label 
        { 
            get { return this.label; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The label must not be blank!");
                }

                this.label = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The price must be greater than 0!");
                }

                this.price = value;
            }
        }

        public int Quantity 
        {
            get { return this.quantity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The quantity can not be negative!");
                }

                this.quantity = value;
            }
        }

        public int CompareTo(IProduct other)
        {
            if (this.Quantity != other.Quantity)
            {
                return this.Quantity - other.Quantity;
            }

            if (this.Price != other.Price)
            {
                return (int)(this.Price * 100)  - (int)(other.Price * 100);
            }

            return this.Label.CompareTo(other.Label);
        }
    }
}
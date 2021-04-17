using System;
using System.Collections.Generic;
using System.Linq;

namespace _03ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public IReadOnlyList<Product> Products
        {
            get { return this.products.AsReadOnly(); }
        }

        public string TryBuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                return $"{this.Name} can't afford {product.Name}";
            }

            this.Money -= product.Cost;
            this.products.Add(product);

            return $"{this.Name} bought {product.Name}";
        }

        public string ReportPurchases()
        {
            string boughtProducts = "Nothing bought";
            if (products.Count > 0)
            {
                boughtProducts = string.Join(", ", this.products.Select(p => p.Name));
            }

            return this.Name + " - " + boughtProducts;
        }
    }
}
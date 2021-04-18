using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> products;

        public ProductStock()
        {
            this.products = new List<IProduct>();
        }

        public IProduct this[int index]
        {
            get 
            {
                if (this.Count == 0)
                {
                    throw new InvalidOperationException("Our stock is empty!");
                }

                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException($"The index must be in range [0..{this.Count - 1}]");
                }

                return this.products[index]; 
            }
            set
            {
                if (this.Count == 0)
                {
                    throw new InvalidOperationException("Our stock is empty!");
                }

                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException($"The index must be in range [0..{this.Count - 1}]");
                }

                this.products[index] = value;
            }
        }

        public int Count => this.products.Count;

        public void Add(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException();
            }

            this.products.Add(product);
        }

        public bool Remove(IProduct product)
        {           
            return this.products.Remove(product);
        }

        public bool Contains(IProduct product)
        {
            return this.products.Contains(product);
        }

        public IProduct Find(int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Our stock is empty!");
            }

            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException($"The index must be in range [0..{this.Count - 1}]");
            }

            return this.products[index];
        }

        public IProduct FindByLabel(string label)
        {
            IProduct product = this.products.FirstOrDefault(p => p.Label == label);
            if (product == null)
            {
                throw new ArgumentException($"There is no {label} in the stock!");
            }

            return product;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("The quantity can not be negative or 0!");
            }

            IEnumerable<IProduct> productsWithGivenQuantity = this.products.Where(p => p.Quantity >= quantity);

            return productsWithGivenQuantity;
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            if (price <= 0)
            {
                throw new ArgumentException("The price must be greater than 0!");
            }

            IEnumerable<IProduct> productsWithGivenPrice = this.products.Where(p => p.Price == (decimal)price);

            return productsWithGivenPrice;
        }        

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            if (lo <= 0 || hi <= 0)
            {
                throw new ArgumentException("The price must be greater than 0!");
            }

            IOrderedEnumerable<IProduct> productsInRange = this.products.Where(p => p.Price >= (decimal)lo && p.Price <= (decimal)hi).OrderByDescending(p => p.Price);

            return productsInRange;
        }        

        public IProduct FindMostExpensiveProduct()
        {
            IProduct product = this.products.OrderByDescending(p => p.Price).FirstOrDefault();
            if (product == null)
            {
                throw new InvalidOperationException("Our stock is empty!");
            }

            return product;
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            for (int i = 0; i < this.products.Count; i++)
            {
                yield return this.products[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
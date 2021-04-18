using INStock.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace INStock.Tests
{
    public class ProductTests
    {
        private const string ProductLabel = "Product";
        private const decimal ProductPrice = 10.09m;
        private const int ProductQuantity = 100;
        private const string InvalidLabelExceptionMessage = "The label must not be blank!";
        private const string InvalidPriceExceptionMessage = "The price must be greater than 0!";
        private const string InvalidQuantityExceptionMessage = "The quantity can not be negative!";

        private Product product;

        [SetUp]
        public void Initialization()
        {
            this.product = new Product(ProductLabel, ProductPrice, ProductQuantity);
        }

        [Test]
        public void InitializeLabel()
        {
            Assert.AreEqual(ProductLabel, product.Label);
        }

        [Test]
        public void InitializePrice()
        {
            Assert.AreEqual(ProductPrice, product.Price);
        }

        [Test]
        public void InitializeQuantity()
        {
            Assert.AreEqual(ProductQuantity, product.Quantity);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        public void InitializeInvalidLabelThrows(string invalidLabel)
        {
            Assert.That(() => this.product = new Product(invalidLabel, ProductPrice, ProductQuantity), Throws.ArgumentException.With.Message.EqualTo(InvalidLabelExceptionMessage));
        }

        [TestCase(0)]
        [TestCase(-1)]        
        public void InitializeInvalidPriceThrows(decimal invalidPrice)
        {
            Assert.That(() => this.product = new Product(ProductLabel, invalidPrice, ProductQuantity), Throws.ArgumentException.With.Message.EqualTo(InvalidPriceExceptionMessage));
        }

        [Test]
        public void InitializeInvalidQuantityThrows()
        {
            Assert.That(() => this.product = new Product(ProductLabel, ProductPrice, -1), Throws.ArgumentException.With.Message.EqualTo(InvalidQuantityExceptionMessage));
        }

        [TestCase("Product1", ProductQuantity)]        
        [TestCase(ProductLabel, 101)]
        public void ComparationWorksCorrectly(string label, int quantity)
        {            
            List<Product> products = new List<Product>();
            products.Add(this.product);
            Product otherProduct = new Product(label, ProductPrice, quantity);
            products.Add(otherProduct);

            Product product = products.OrderBy(p => p).First();

            Assert.AreEqual(this.product, product);
        }
        
        [Test]
        public void ComparationWorksCorrectlyWithPrices()
        {
            List<Product> products = new List<Product>();
            products.Add(this.product);
            Product otherProduct = new Product(ProductLabel, 10.10m, ProductQuantity);
            products.Add(otherProduct);

            Product product = products.OrderBy(p => p).First();

            Assert.AreEqual(this.product, product);
        }
    }
}
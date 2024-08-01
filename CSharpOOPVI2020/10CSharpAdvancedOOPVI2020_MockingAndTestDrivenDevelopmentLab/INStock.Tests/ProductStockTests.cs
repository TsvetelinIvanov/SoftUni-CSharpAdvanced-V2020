using INStock.Models;
using NUnit.Framework;
using Moq;
using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INStock.Tests//The Mock objects cannot compare well by references - in these cases real objects must be used!
{
    public class ProductStockTests
    {
        private const string IndexOutOfRangeExceptionMessage = "The index must be in range [0..{0}]";        
        private const string NonExistentLabelExceptionMessage = "There is no {0} in the stock!";
        private const string InvalidPriceExceptionMessage = "The price must be greater than 0!";
        private const string InvalidQuantityExceptionMessage = "The quantity can not be negative or 0!";        
        private const string EmptyStockExceptionMessage = "Our stock is empty!";

        private readonly Product product1 = new Product("Product1", 10.09m, 100);
        private readonly Product product2 = new Product("Product2", 9.99m, 10);
        private readonly Product product3 = new Product("Product3", 10.10m, 1000);

        private ProductStock products;
        private Mock<IProduct> fakeProduct1;
        private Mock<IProduct> fakeProduct2;
        private Mock<IProduct> fakeProduct3;

        [SetUp]
        public void Initialization()
        {
            this.products = new ProductStock();
            
            this.fakeProduct1 = new Mock<IProduct>();
            fakeProduct1.Setup(fp => fp.Label).Returns("FakeProduct1");
            fakeProduct1.Setup(fp => fp.Price).Returns(10.09m);
            fakeProduct1.Setup(fp => fp.Quantity).Returns(100);
            
            this.fakeProduct2 = new Mock<IProduct>();
            fakeProduct1.Setup(fp => fp.Label).Returns("FakeProduct2");
            fakeProduct1.Setup(fp => fp.Price).Returns(9.99m);
            fakeProduct1.Setup(fp => fp.Quantity).Returns(10);
            
            this.fakeProduct3 = new Mock<IProduct>();
            fakeProduct1.Setup(fp => fp.Label).Returns("FakeProduct3");
            fakeProduct1.Setup(fp => fp.Price).Returns(10.10m);
            fakeProduct1.Setup(fp => fp.Quantity).Returns(1000);
        }

        [Test]
        public void InitializeEmptyCollection()
        {
            Assert.AreEqual(0, this.products.Count);
        }

        [Test]
        public void AddAddsGivenProducts()
        {
            this.products.Add(this.fakeProduct1.Object);
            this.products.Add(this.fakeProduct2.Object);
            this.products.Add(this.fakeProduct3.Object);

            Assert.AreEqual(3, this.products.Count);
        }

        [Test]
        public void AddNullThrows()
        {
            Assert.That(() => this.products.Add(null), Throws.ArgumentNullException);
        }

        [Test]
        public void IndexerReturnsCorrectly()
        {
            this.products.Add(this.fakeProduct1.Object);
            this.products.Add(this.fakeProduct2.Object);

            IProduct product = products[1];

            Assert.AreEqual(this.fakeProduct2.Object, product);
        }

        [Test]
        public void IndexerSetCorrectly()
        {
            this.products.Add(this.fakeProduct1.Object);
            this.products.Add(this.fakeProduct2.Object);

            products[1] = fakeProduct3.Object;
            IProduct product = products[1];

            Assert.AreEqual(this.fakeProduct3.Object, product);
        }

        [Test]
        public void IndexerThrowsIfEmptyStock()
        {
            Assert.That(() => this.products[0], Throws.InvalidOperationException.With.Message.EqualTo(EmptyStockExceptionMessage));
        }

        [TestCase(-1)]
        [TestCase(2)]
        public void IndexerThrowsIfTryGetOutOfRange(int index)
        {
            this.products.Add(this.fakeProduct1.Object);
            this.products.Add(this.fakeProduct2.Object);

            try
            {
                IProduct product = this.products[index];
            }
            catch (IndexOutOfRangeException ioore)
            {
                Assert.AreEqual(string.Format(IndexOutOfRangeExceptionMessage, 1), ioore.Message);
            }           
        }

        [TestCase(-1)]
        [TestCase(2)]
        public void IndexerThrowsIfTrySetOutOfRange(int index)
        {
            this.products.Add(this.fakeProduct1.Object);
            this.products.Add(this.fakeProduct2.Object);

            try
            {
                this.products[index] = this.fakeProduct3.Object;
            }
            catch (IndexOutOfRangeException ioore)
            {
                Assert.AreEqual(string.Format(IndexOutOfRangeExceptionMessage, 1), ioore.Message);
            }
        }

        [Test]
        public void RemoveRemovesCorrectly()
        {
            this.products.Add(this.fakeProduct1.Object);
            this.products.Add(this.fakeProduct2.Object);
            this.products.Add(this.fakeProduct3.Object);

            bool isRemoved = this.products.Remove(this.fakeProduct2.Object);

            Assert.IsTrue(isRemoved);
            Assert.AreEqual(2, this.products.Count);
            Assert.AreEqual(this.fakeProduct3.Object, this.products[1]);
        }

        [Test]
        public void RemoveNotRemovesIfNotExists()
        {
            this.products.Add(this.fakeProduct1.Object);            
            this.products.Add(this.fakeProduct3.Object);

            bool isRemoved = this.products.Remove(this.fakeProduct2.Object);

            Assert.IsFalse(isRemoved);
            Assert.AreEqual(2, this.products.Count);            
        }

        [Test]
        public void ContainsReturnsTrueIfExists()
        {
            this.products.Add(this.fakeProduct1.Object);
            this.products.Add(this.fakeProduct2.Object);
            this.products.Add(this.fakeProduct3.Object);

            bool contains = this.products.Contains(this.fakeProduct2.Object);

            Assert.IsTrue(contains);            
        }

        [Test]
        public void ContainsReturnsFalseIfNotExists()
        {
            this.products.Add(this.fakeProduct1.Object);            
            this.products.Add(this.fakeProduct3.Object);

            bool contains = this.products.Contains(this.fakeProduct2.Object);

            Assert.IsFalse(contains);
        }

        [Test]
        public void FindReturnsCorrectly()
        {
            this.products.Add(this.fakeProduct1.Object);
            this.products.Add(this.fakeProduct2.Object);
            this.products.Add(this.fakeProduct3.Object);

            IProduct product = this.products.Find(1);

            Assert.AreEqual(this.fakeProduct2.Object, product);
        }

        [Test]
        public void FindThrowsIfEmptyStock()
        {
            Assert.That(() => this.products.Find(0), Throws.InvalidOperationException.With.Message.EqualTo(EmptyStockExceptionMessage));
        }

        [TestCase(-1)]
        [TestCase(2)]
        public void FindThrowsIfTryFindOtOfRange(int index)
        {
            this.products.Add(this.fakeProduct1.Object);
            this.products.Add(this.fakeProduct2.Object);

            try
            {
                IProduct product = this.products.Find(index);
            }
            catch (IndexOutOfRangeException ioore)
            {
                Assert.AreEqual(string.Format(IndexOutOfRangeExceptionMessage, 1), ioore.Message);
            }
        }

        [Test]
        public void FindByLabelReturnsCorrectly()
        {
            this.products.Add(this.product1);
            this.products.Add(this.product2);
            this.products.Add(this.product3);

            IProduct product = this.products.FindByLabel("Product1");

            Assert.AreEqual(this.product1, product);
        }

        [Test]
        public void FindByLabelThrowsIfNoExists()
        {
            this.products.Add(this.product1);
            this.products.Add(this.product2);            
                       
            Assert.That(() => this.products.FindByLabel("Product3"), Throws.ArgumentException.With.Message.EqualTo(string.Format(NonExistentLabelExceptionMessage, "Product3")));
        }

        [Test]
        public void FindAllByQuantityReturnsCorrectly()
        {
            this.products.Add(this.product1);
            this.products.Add(this.product2);
            this.products.Add(this.product3);

            IProduct[] productsWithGivenQuantity = this.products.FindAllByQuantity(100).ToArray();

            Assert.AreEqual(2, productsWithGivenQuantity.Length);
            Assert.AreEqual(this.product1, productsWithGivenQuantity[0]);
            Assert.AreEqual(this.product3, productsWithGivenQuantity[1]);
        }

        [Test]
        public void FindAllByQuantityReturnsEmptyCollectionIfNoExists()
        {
            this.products.Add(this.fakeProduct1.Object);
            this.products.Add(this.fakeProduct2.Object);
            this.products.Add(this.fakeProduct3.Object);

            IProduct[] productsWithGivenQuantity = this.products.FindAllByQuantity(1001).ToArray();

            Assert.AreEqual(0, productsWithGivenQuantity.Length);            
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void FindAllByQuantityThrowsIfIvalidQuantity(int invalidQuantity)
        {
            this.products.Add(this.fakeProduct1.Object);
            this.products.Add(this.fakeProduct2.Object);
            this.products.Add(this.fakeProduct3.Object);            

            Assert.That(() => this.products.FindAllByQuantity(invalidQuantity), Throws.ArgumentException.With.Message.EqualTo(InvalidQuantityExceptionMessage));
        }

        [Test]
        public void FindAllByPriceReturnsCorrectly()
        {
            this.products.Add(this.product1);
            this.products.Add(this.product2);
            this.products.Add(this.product3);

            IProduct[] productsWithGivenPrice = this.products.FindAllByPrice(10.09).ToArray();

            Assert.AreEqual(1, productsWithGivenPrice.Length);
            Assert.AreEqual(this.product1, productsWithGivenPrice[0]);           
        }

        [Test]
        public void FindAllByPriceReturnsEmptyCollectionIfNoExists()
        {
            this.products.Add(this.fakeProduct1.Object);
            this.products.Add(this.fakeProduct2.Object);
            this.products.Add(this.fakeProduct3.Object);

            IProduct[] productsWithGivenPrice = this.products.FindAllByPrice(10.11).ToArray();

            Assert.AreEqual(0, productsWithGivenPrice.Length);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void FindAllByPriceThrowsIfIvalidPrice(double invalidPrice)
        {
            this.products.Add(this.fakeProduct1.Object);
            this.products.Add(this.fakeProduct2.Object);
            this.products.Add(this.fakeProduct3.Object);

            Assert.That(() => this.products.FindAllByPrice(invalidPrice), Throws.ArgumentException.With.Message.EqualTo(InvalidPriceExceptionMessage));
        }

        [Test]
        public void FindAllInRangeReturnsCorrectly()
        {
            this.products.Add(this.product1);
            this.products.Add(this.product2);
            this.products.Add(this.product3);

            IProduct[] productsWithGivenPriceRange = this.products.FindAllInRange(10, 10.10).ToArray();

            Assert.AreEqual(2, productsWithGivenPriceRange.Length);
            Assert.AreEqual(this.product3, productsWithGivenPriceRange[0]);
            Assert.AreEqual(this.product1, productsWithGivenPriceRange[1]);
        }

        [Test]
        public void FindAllInRangeReturnsEmptyCollectionIfNoExists()
        {
            this.products.Add(this.fakeProduct1.Object);
            this.products.Add(this.fakeProduct2.Object);
            this.products.Add(this.fakeProduct3.Object);

            IProduct[] productsWithGivenPriceRange = this.products.FindAllInRange(10.11, 11).ToArray();

            Assert.AreEqual(0, productsWithGivenPriceRange.Length);
        }

        [TestCase(0, 10)]
        [TestCase(10, 0)]
        [TestCase(-10, 10)]
        [TestCase(10, -10)]
        public void FindAllByPriceThrowsIfIvalidPrice(double invalidLowPrice, double invalidHighPrice)
        {
            this.products.Add(this.fakeProduct1.Object);
            this.products.Add(this.fakeProduct2.Object);
            this.products.Add(this.fakeProduct3.Object);

            Assert.That(() => this.products.FindAllInRange(invalidLowPrice, invalidHighPrice), Throws.ArgumentException.With.Message.EqualTo(InvalidPriceExceptionMessage));
        }

        [Test]
        public void FindMostExpensiveProductReturnsCorrectly()
        {
            this.products.Add(this.product1);
            this.products.Add(this.product2);
            this.products.Add(this.product3);

            IProduct mostExpensiveProduct = this.products.FindMostExpensiveProduct();
            
            Assert.AreEqual(this.product3, mostExpensiveProduct);
        }

        [Test]
        public void FindMostExpensiveProductThrowsIfEmptyStock()
        {
            Assert.That(() => this.products.FindMostExpensiveProduct(), Throws.InvalidOperationException.With.Message.EqualTo(EmptyStockExceptionMessage));
        }

        [Test]
        public void GetEnumeratorWorksCorrectly()
        {
            this.products.Add(this.product1);
            this.products.Add(this.product2);
            this.products.Add(this.product3);

            string productLabelsString = string.Empty;
            foreach (IProduct product in this.products)
            {
                productLabelsString += product.Label + " ";
            }

            productLabelsString = productLabelsString.TrimEnd();

            string expectedProductLabelsString = this.product1.Label + " " + this.product2.Label + " " + this.product3.Label;

            Assert.AreEqual(expectedProductLabelsString, productLabelsString);
        }
    }
}

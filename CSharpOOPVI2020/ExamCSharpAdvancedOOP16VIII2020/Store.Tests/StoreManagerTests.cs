using NUnit.Framework;
using System.Linq;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        private const string AddProductNullExceptionMessage = "Value cannot be null. (Parameter 'product')";
        private const string NotPositiveQuantityExceptionMessage = "Product count can't be below or equal to zero.";
        private const string NoSuchProductExceptionMessage = "There is no such product.";
        private const string BuyProductNullExceptionMessage = NoSuchProductExceptionMessage + " (Parameter 'product')";
        private const string NotEnoughQuantityExceptionMessage = "There is not enough quantity of this product.";
        private const int BuyQuantity = 2;
        private const int RemainQuantity = 1;
        private const decimal BuyPrice = 6.06m;

        private Product product1;
        private Product product2;
        private Product product3;

        private StoreManager storeManager;

        [SetUp]
        public void Setup()
        {
            this.product1 = new Product("Product1", 1, 1.01m);
            this.product2 = new Product("Product2", 2, 2.02m);
            this.product3 = new Product("Product3", 3, 3.03m);

            this.storeManager = new StoreManager();
        }

        [Test]
        public void InitializationProductCorrectly()
        {
            Assert.AreEqual("Product1", this.product1.Name);
            Assert.AreEqual(1, this.product1.Quantity);
            Assert.AreEqual(1.01, this.product1.Price);
        }

        [Test]
        public void SetCorrectlyProductQuantity()
        {
            this.product1.Quantity = 4;
            Assert.AreEqual(4, this.product1.Quantity);
        }

        [Test]
        public void InitializationWithEmptyCollection()
        {
            Assert.AreEqual(0, this.storeManager.Count);
        }

        [Test]
        public void AddProductWorksCorrectly()
        {
            this.storeManager.AddProduct(this.product1);
            this.storeManager.AddProduct(this.product2);
            this.storeManager.AddProduct(this.product3);

            Assert.AreEqual(3, this.storeManager.Count);
            Assert.IsTrue(this.storeManager.Products.Contains(product1));
            Assert.IsTrue(this.storeManager.Products.Contains(product2));
            Assert.IsTrue(this.storeManager.Products.Contains(product3));
        }

        [Test]
        public void AddProductThrowsIfNull()
        {
            this.storeManager.AddProduct(this.product1);
            this.storeManager.AddProduct(this.product2);

            Assert.That(() => this.storeManager.AddProduct(null), Throws.ArgumentNullException.With.Message.EqualTo(AddProductNullExceptionMessage));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void AddProductThrowsIfInvalidQuantity(int invalidQuantity)
        {
            this.storeManager.AddProduct(this.product1);
            this.storeManager.AddProduct(this.product2);
            this.product3.Quantity = invalidQuantity;

            Assert.That(() => this.storeManager.AddProduct(product3), Throws.ArgumentException.With.Message.EqualTo(NotPositiveQuantityExceptionMessage));
        }

        [Test]
        public void BuyProductWorksCorrectly()
        {
            this.storeManager.AddProduct(this.product1);
            this.storeManager.AddProduct(this.product2);
            this.storeManager.AddProduct(this.product3);

            decimal price = this.storeManager.BuyProduct(this.product3.Name, BuyQuantity);

            Assert.AreEqual(BuyPrice, price);
            Assert.AreEqual(RemainQuantity, this.product3.Quantity);
        }

        [Test]
        public void BuyProductThrowsIfNotProduct()
        {
            this.storeManager.AddProduct(this.product1);
            this.storeManager.AddProduct(this.product2);

            Assert.That(() => this.storeManager.BuyProduct(this.product3.Name, BuyQuantity), Throws.ArgumentNullException.With.Message.EqualTo(BuyProductNullExceptionMessage));
        }

        [Test]
        public void BuyProductThrowsIfNotEnoughQuantity()
        {
            this.storeManager.AddProduct(this.product1);
            this.storeManager.AddProduct(this.product2);

            Assert.That(() => this.storeManager.BuyProduct(this.product1.Name, BuyQuantity), Throws.ArgumentException.With.Message.EqualTo(NotEnoughQuantityExceptionMessage));
        }

        [Test]
        public void GetTheMostExpensiveProductWorksCorrectly()
        {
            this.storeManager.AddProduct(this.product1);
            this.storeManager.AddProduct(this.product2);
            this.storeManager.AddProduct(this.product3);

            Product product = this.storeManager.GetTheMostExpensiveProduct();

            Assert.AreEqual(this.product3, product);            
        }
    }
}
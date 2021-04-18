using System;
using INStock.Models;
using INStock.Contracts;

namespace INStock
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("Product1", 10, 100);
            Product product2 = new Product("Product2", 10, 100);
            Product product3 = new Product("Product3", 10, 100);
            ProductStock products = new ProductStock();
            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            IProduct product = products.FindByLabel("Product1");
            Console.WriteLine(product.Label);
        }
    }
}
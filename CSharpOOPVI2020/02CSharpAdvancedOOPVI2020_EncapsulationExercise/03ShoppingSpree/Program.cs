using System;
using System.Collections.Generic;
using System.Linq;

namespace _03ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            string[] peopleData = Console.ReadLine().Split(';');
            string[] productsData = Console.ReadLine().Split(';');

            try
            {
                foreach (string personData in peopleData.Where(pd => pd != string.Empty))
                {
                    string name = personData.Split('=').FirstOrDefault();
                    decimal money = decimal.Parse(personData.Split('=').LastOrDefault());
                    Person person = new Person(name, money);
                    people.Add(person);
                }

                foreach (string productData in productsData.Where(pd => pd != string.Empty))
                {
                    string name = productData.Split('=').FirstOrDefault();
                    decimal cost = decimal.Parse(productData.Split('=').LastOrDefault());
                    Product product = new Product(name, cost);
                    products.Add(product);
                }

                string purchaseData;
                while ((purchaseData = Console.ReadLine()) != "END")
                {
                    string personName = purchaseData.Split().FirstOrDefault();
                    string productName = purchaseData.Split().LastOrDefault();
                    Person person = people.FirstOrDefault(p => p.Name == personName);
                    Product product = products.FirstOrDefault(p => p.Name == productName);
                    string purchaseReport = person.TryBuyProduct(product);
                    Console.WriteLine(purchaseReport);
                }

                foreach (Person person in people)
                {
                    Console.WriteLine(person.ReportPurchases());
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }           
        }
    }
}

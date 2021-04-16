using System;
using System.Collections.Generic;
using System.Linq;

namespace _03ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();
            string input;
            while((input = Console.ReadLine()) != "Revision")
            {
                string[] productInfo = input.Split(", ");
                string shop = productInfo[0];
                string product = productInfo[1];
                double price = double.Parse(productInfo[2]);
                
                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                }

                shops[shop].Add(product, price);
            }

            Dictionary<string, Dictionary<string, double>> orderedShops = shops.OrderBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);

            foreach (KeyValuePair<string, Dictionary<string, double>> shop in orderedShops)
            {
                Console.WriteLine(shop.Key + "->");
                foreach (KeyValuePair<string, double> product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
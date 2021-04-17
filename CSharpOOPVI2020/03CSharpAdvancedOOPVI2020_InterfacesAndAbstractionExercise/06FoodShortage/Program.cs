using System;
using System.Collections.Generic;
using System.Linq;

namespace _06FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IPerson> buyers = new List<IPerson>();
            int buyersCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < buyersCount; i++)
            {
                string[] buyersData = Console.ReadLine().Split();
                
                if (buyersData.Length == 4)
                {
                    string name = buyersData[0];
                    int age = int.Parse(buyersData[1]);
                    string id = buyersData[2];
                    string birthdate = buyersData[3];
                    Citizen citizen = new Citizen(id, name, age, birthdate);
                    buyers.Add(citizen);
                }
                else if (buyersData.Length == 3)
                {
                    string name = buyersData[0];
                    int age = int.Parse(buyersData[1]);
                    string group = buyersData[2];
                    Rabel rabel = new Rabel(name, age, group);
                    buyers.Add(rabel);
                }
            }

            string buyerName = string.Empty;
            while ((buyerName = Console.ReadLine()) != "End")
            {
                IBuyer buyer = buyers.FirstOrDefault(b => b.Name == buyerName);
                if (buyer == null)
                {
                    continue;
                }

                buyer.BuyFood();
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
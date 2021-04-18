using System;

namespace _02Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleGift phone = new SingleGift("Phone", 256);
            phone.CalculateTotalPrice();//Phone with the price 256

            CompositeGift rootBox = new CompositeGift("Root box", 0);
            SingleGift truckToy = new SingleGift("Truck toy", 289);
            SingleGift plainToy = new SingleGift("Plain toy", 587);
            rootBox.Add(truckToy);
            rootBox.Add(plainToy);
            CompositeGift childBox = new CompositeGift("Child box", 0);
            SingleGift soldierToy = new SingleGift("Soldier toy", 200);
            childBox.Add(soldierToy);
            rootBox.Add(childBox);

            Console.WriteLine("Total price of this composite present is: " + rootBox.CalculateTotalPrice());
            //Root box contains the following products with prices:
            //Truck toy with the price 289
            //Plain toy with the price 587
            //Child box contains the following products with prices:
            //Soldier toy with the price 200
            //Total price of this composite present is: 1076
        }
    }
}
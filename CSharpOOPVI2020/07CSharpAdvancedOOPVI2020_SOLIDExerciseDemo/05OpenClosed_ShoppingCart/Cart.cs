using _05OpenClosed_ShoppingCart.Contracts;
using _05OpenClosed_ShoppingCart.Rules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05OpenClosed_ShoppingCart
{
    public class Cart
    {
        private readonly List<OrderItem> items;

        public Cart()
        {
            this.items = new List<OrderItem>();
        }

        public IEnumerable<OrderItem> Items
        {
            get { return new List<OrderItem>(this.items); }
        }

        public string CustmerEmail { get; set; }

        public void Add(OrderItem orderItem)
        {
            this.items.Add(orderItem);
        }

        public decimal TotalAmount()
        {
            decimal total = 0m;
            List<IAmountRule> amountRules = new List<IAmountRule>()
                {
                    new EachAmountRule(),
                    new WeightAmountRule(),
                    new SpecialAmountRule(),
                    // more rules are coming!
                };
            
            foreach (OrderItem item in this.items)
            {
                IAmountRule amountRule = amountRules.FirstOrDefault(r => r.IsMatch(item));
                if (amountRule == null)
                {
                    throw new ArgumentException($"The pricing type \"{item.Sku}\" is not supported from ouer pricing rules!");
                }

                total += amountRule.Calculate(item);
            }

            return total;
        }
    }
}
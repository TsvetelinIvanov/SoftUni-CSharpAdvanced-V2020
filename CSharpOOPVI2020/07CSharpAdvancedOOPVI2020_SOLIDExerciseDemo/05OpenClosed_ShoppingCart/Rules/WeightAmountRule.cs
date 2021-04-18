using _05OpenClosed_ShoppingCart.Contracts;

namespace _05OpenClosed_ShoppingCart.Rules
{
    public class WeightAmountRule : IAmountRule
    {
        public decimal Calculate(OrderItem orderItem)
        {
            // quantity is in grams, price is per kg
            return orderItem.Quantity * 4m / 1000;
        }

        public bool IsMatch(OrderItem orderItem)
        {
            return orderItem.Sku.StartsWith("WEIGHT");
        }
    }
}
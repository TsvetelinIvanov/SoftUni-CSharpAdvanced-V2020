using _05OpenClosed_ShoppingCart.Contracts;

namespace _05OpenClosed_ShoppingCart.Rules
{
    public class EachAmountRule : IAmountRule
    {
        public decimal Calculate(OrderItem orderItem)
        {
           return orderItem.Quantity * 5m;
        }

        public bool IsMatch(OrderItem orderItem)
        {
            return orderItem.Sku.StartsWith("EACH");
        }
    }
}
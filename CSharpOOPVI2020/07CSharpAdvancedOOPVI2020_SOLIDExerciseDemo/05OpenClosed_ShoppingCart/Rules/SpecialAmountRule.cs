using _05OpenClosed_ShoppingCart.Contracts;

namespace _05OpenClosed_ShoppingCart.Rules
{
    public class SpecialAmountRule : IAmountRule
    {
        public decimal Calculate(OrderItem orderItem)
        {
            // $0.40 each; 3 for $1.00
            decimal total = 0;
            total += orderItem.Quantity * .4m;
            int setsOfThree = orderItem.Quantity / 3;
            total -= setsOfThree * .2m;
            return total;
        }

        public bool IsMatch(OrderItem orderItem)
        {
            return orderItem.Sku.StartsWith("SPECIAL");
        }
    }
}
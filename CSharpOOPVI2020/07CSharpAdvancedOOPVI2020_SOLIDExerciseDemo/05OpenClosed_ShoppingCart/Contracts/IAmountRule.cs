namespace _05OpenClosed_ShoppingCart.Contracts
{
    public interface IAmountRule
    {
        decimal Calculate(OrderItem orderItem);

        bool IsMatch(OrderItem orderItem);
    }
}
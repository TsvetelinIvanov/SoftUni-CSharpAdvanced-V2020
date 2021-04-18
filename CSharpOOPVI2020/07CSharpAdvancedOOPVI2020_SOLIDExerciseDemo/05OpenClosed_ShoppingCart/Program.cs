namespace _05OpenClosed_ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderItem itemEach = new OrderItem("EACHPRICING", 1000);
            OrderItem itemWeight = new OrderItem("WEIGHTPRICING", 100000);// quantity is in grams, price is per kg, i.e. real quantity is 100
            OrderItem itemSpecial = new OrderItem("SPECIALPRICING", 10);
            Cart cart = new Cart();
            cart.Add(itemEach);
            cart.Add(itemWeight);
            cart.Add(itemSpecial);
            OnlineOrder onlineOrder = new OnlineOrder(cart);
            onlineOrder.Checkout();//5403.4
        }
    }
}
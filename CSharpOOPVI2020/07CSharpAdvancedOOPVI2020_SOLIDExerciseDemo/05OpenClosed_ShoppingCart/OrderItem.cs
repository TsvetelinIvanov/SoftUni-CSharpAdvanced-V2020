namespace _05OpenClosed_ShoppingCart
{
    public class OrderItem
    {
        public OrderItem(string sku, int quantity)
        {
            this.Sku = sku;
            this.Quantity = quantity;
        }

        public void ChangeSku(string sku)
        {
            this.Sku = sku;
        }

        public void ChangeQuantity(int quantity)
        {
            this.Quantity = quantity;
        }

        public string Sku { get; private set; }

        public int Quantity { get; private set; }
    }
}
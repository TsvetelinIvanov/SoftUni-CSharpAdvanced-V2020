using System;

namespace Store
{
    class Program
    {
        static void Main(string[] args)
        {
            StoreManager storeManager = new StoreManager();
            storeManager.AddProduct(null);
        }
    }
}
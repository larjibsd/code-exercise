namespace Advertisement.Domain
{
    public class Product
    {
        public Product(string productId, double price)
        {
            ProductId = productId;
            Price = price;
        }

        public string ProductId { get; }

        public double Price { get; private set; }

        public void UpdatePrice(double price)
        {
            Price = price;
        }
    }
}
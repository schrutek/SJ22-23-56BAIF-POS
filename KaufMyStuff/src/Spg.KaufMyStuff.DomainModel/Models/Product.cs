namespace Spg.KaufMyStuff.DomainModel.Models
{
    public class Product
    {
        public string Name { get; private set;  } = string.Empty;
        public decimal Price { get; set; }
        public int Tax { get; set; }
        public string Ean { get; set; } = string.Empty;
        public string? Material { get; set; } = string.Empty;
        public DateTime? ExpiryDate { get; set; }

        private List<ShoppingCartItem> _shoppingCartItems = new();
        public IReadOnlyList<ShoppingCartItem> ShoppingCartItems => _shoppingCartItems;

        public Product(string name, decimal price, int tax, string ean, string? material, DateTime? expiryDate)
        {
            Name = name;
            Price = price;
            Tax = tax;
            Ean = ean;
            Material = material;
            ExpiryDate = expiryDate;
        }
    }
}

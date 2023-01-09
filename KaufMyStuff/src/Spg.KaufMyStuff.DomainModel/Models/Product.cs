namespace Spg.KaufMyStuff.DomainModel.Models
{
    public class Product
    {
        public string Name { get; private set; } = string.Empty;
        public int Tax { get; set; }
        public string Ean { get; set; } = string.Empty;
        public string? Material { get; set; } = string.Empty;
        public DateTime? ExpiryDate { get; set; }

        public List<ShoppingCartItem> _shoppingCartItems = new();
        public virtual IReadOnlyList<ShoppingCartItem> ShoppingCartItems => _shoppingCartItems;

        protected List<Price> _prices = new();
        public virtual IReadOnlyList<Price> Prices => _prices;


        public int CategoryId { get; set; }
        public virtual Category CategoryNavigation { get; private set; } = default!;


        protected Product()
        { }
        public Product(string name, int tax, string ean, string? material, DateTime? expiryDate, Category category)
        {
            Name = name;
            Tax = tax;
            Ean = ean;
            Material = material;
            ExpiryDate = expiryDate;
            CategoryNavigation = category;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Models
{
    public class Product
    {
        public Product(string name, decimal price, int tax, string ean, string? material, DateTime? expiryDate)
        {
            Name = name;
            Price = price;
            Tax = tax;
            Ean = ean;
            Material = material;
            ExpiryDate = expiryDate;
        }

        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Tax { get; set; }
        public string Ean { get; set; } = string.Empty;
        public string? Material { get; set; } = string.Empty;
        public DateTime? ExpiryDate { get; set; }

        public List<ShoppingCartItem> _shoppingCartItems = new();
        public IReadOnlyList<ShoppingCartItem> ShoppingCartItems => _shoppingCartItems;
    }
}

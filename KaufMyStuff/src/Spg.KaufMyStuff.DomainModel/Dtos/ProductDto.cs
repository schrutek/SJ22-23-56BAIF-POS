using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Dtos
{
    public class ProductDto
    {
        public string ProductName { get; set; } = string.Empty;
        public string Ean13 { get; set; } = string.Empty;
        public string? Material { get; set; } = string.Empty;
        public DateTime? ExpiryDate { get; set; }
        public string? CategoryName { get; set; } = string.Empty;

        public List<ShoppingCartItemDto> ShoppingCartItems { get; set; } = new();
        public int ShoppingCartItemsCount => ShoppingCartItems.Count;
    }
}

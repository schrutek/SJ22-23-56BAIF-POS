using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Models
{
    public enum ShoppingCartStates { Active = 0, Sent = 1, Unknown = 99 }
    
    public class ShoppingCart : EntityBase
    {
        public int Id { get; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Sum { get; }
        public ShoppingCartStates ShoppingCartState { get; set; }
        public DateTime CreationDate { get; }
        
        private List<ShoppingCartItem> _shoppingCartItems = new();

        public IReadOnlyList<ShoppingCartItem> ShoppingCartItems => _shoppingCartItems;  

        public int CustomerNavigationId { get; }
        public Customer CustomerNavigation { get; } = default!;

        public ShoppingCart(string name, string description, ShoppingCartStates shoppingCartState)
        {
            Name = name;
            Description = description;
            ShoppingCartState = shoppingCartState;
        }
    }
}

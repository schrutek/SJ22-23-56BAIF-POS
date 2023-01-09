using Spg.KaufMyStuff.DomainModel.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Models
{
    public class ShoppingCart : EntityBase
    {
        public Guid Guid { get; set; }
        public string Name { get; set; } = string.Empty;
        public ShoppingCartStates ShoppingCartState { get; set; }
        public DateTime CreationDate { get; private set; }
        public int ItemsCount { get; private set; }
        public decimal Summary { get; private set; }

        public int CustomerNavigationId { get; set; }
        public virtual Customer CustomerNavigation { get; set; } = default!;

        private List<ShoppingCartItem> _shoppingCartItems = new();
        public virtual IReadOnlyList<ShoppingCartItem> ShoppingCartItems => _shoppingCartItems;

        protected ShoppingCart()
        { }
        public ShoppingCart(string name, ShoppingCartStates shoppingCartState, DateTime creationDate, Customer customer, Guid guid)
        {
            Name = name;
            ShoppingCartState = shoppingCartState;
            CreationDate = creationDate;
            Guid = guid;
            CustomerNavigation = customer;
        }
    }
}

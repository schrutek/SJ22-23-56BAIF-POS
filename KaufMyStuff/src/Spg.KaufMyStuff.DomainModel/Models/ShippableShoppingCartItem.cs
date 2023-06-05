using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Models
{
    public class ShippableShoppingCartItem : ShoppingCartItem
    {
        public Address Address { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected ShippableShoppingCartItem()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        { }
        public ShippableShoppingCartItem(
            ShoppingCart shoppingCartNavigation, 
            Product productNavigation, 
            Address address)
            : base(shoppingCartNavigation, productNavigation)
        {
            Address = address;
        }
    }
}

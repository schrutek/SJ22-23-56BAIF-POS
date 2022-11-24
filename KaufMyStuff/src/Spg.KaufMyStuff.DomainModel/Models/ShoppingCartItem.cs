using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Models
{
    public class ShoppingCartItem : EntityBase
    {
        public int ProductNavigationId { get; }
        public Product ProductNavigation { get; } = default!;

        public int ShoppingCartNavigationId { get; set; }
        public ShoppingCart ShoppingCart { get; set; } = default!;

        public ShoppingCartItem()
        { }
    }
}

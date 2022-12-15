using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Models
{
    public class ShoppingCartItem : EntityBase
    {
        public int ProductNavigationId { get; private set;  }
        public Product ProductNavigation { get; } = default!;

        public int ShoppingCartNavigationId { get; private set; }
        public ShoppingCart ShoppingCart { get; private set; } = default!;

        public ShoppingCartItem()
        { }
    }
}

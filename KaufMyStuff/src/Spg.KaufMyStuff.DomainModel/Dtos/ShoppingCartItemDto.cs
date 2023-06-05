using Spg.KaufMyStuff.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Dtos
{
    public class ShoppingCartItemDto
    {
        public int Id { get; set; }
        public bool IsShippable { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Models
{
    public class Shop : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public Address Address { get; set; } = default!;

        protected Shop()
        { }
        public Shop(string name)
        {
            Name = name;
        }
    }
}

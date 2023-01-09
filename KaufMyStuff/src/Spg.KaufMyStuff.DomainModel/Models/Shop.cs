using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Models
{
    public class Shop : EntityBase
    {
        protected Shop() { }
        public Shop(
            string companySuffix, 
            string name, 
            string location, 
            string catchPhrase, 
            string bs, 
            Address address, 
            Guid guid)
        {
            CompanySuffix = companySuffix;
            Name = name;
            Location = location;
            CatchPhrase = catchPhrase;
            Bs = bs;
            Address = address;
            Guid = guid;
        }

        public string CompanySuffix { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string CatchPhrase { get; set; } = string.Empty;
        public string Bs { get; set; } = string.Empty;
        public Guid Guid { get; private set; }
        public Address Address { get; set; } = default!;


        protected List<Category> _categories = new();
        public virtual IReadOnlyList<Category> Categories => _categories;
    }
}

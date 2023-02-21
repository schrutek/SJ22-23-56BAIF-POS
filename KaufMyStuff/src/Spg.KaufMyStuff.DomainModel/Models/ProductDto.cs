using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Models
{
    public class ProductDto
    {
        public string ProductName { get; set; } = string.Empty;
        public string Ean13 { get; set; } = string.Empty;
        
        
        public string SelectedName { get; set; } = string.Empty;
    }
}

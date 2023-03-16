using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Dtos
{
    public record CreateProductDto(
        string Name, 
        int Tax, 
        string Ean, 
        string? Material, 
        DateTime? ExpiryDate, 
        Guid CategoryId
    ) 
    { }
}

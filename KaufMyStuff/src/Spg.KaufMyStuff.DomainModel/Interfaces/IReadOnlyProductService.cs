using Spg.KaufMyStuff.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Interfaces
{
    public interface IReadOnlyProductService
    {
        IQueryable<Product> Products { get; set; }

        IReadOnlyProductService Load();
        IEnumerable<Product> GetData();
        IEnumerable<Product> GetDataPaged(int pageIndex, int pageSize);
    }
}

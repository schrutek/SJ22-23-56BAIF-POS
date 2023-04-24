using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Interfaces
{
    public interface IFindableByGuid
    {
        public Guid Guid { get; }
    }
}

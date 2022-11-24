using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Models
{
    public class EntityBase
    {
        public int Id { get; }
        public DateTime? LastChangeDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Dtos
{
    public class RoleDto
    {
        public string Key { get; set; } = string.Empty; // (key, unique) guest, admin
        public string Description { get; set; } = string.Empty;
        public List<PermissionDto> Permisson { get; set; } = new();
    }
}

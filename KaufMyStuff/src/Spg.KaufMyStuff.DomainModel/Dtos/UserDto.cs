using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Dtos
{
    public class UserDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;
        public string Fullname => $"{FirstName} {LastName}";
        public RoleDto Role { get; set; } = new RoleDto() { Key = "guest" };
        public string? Signature { get; set; }
    }
}

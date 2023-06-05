using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Dtos
{
    public class LoginDto
    {
        public string UserName { get; set; } = string.Empty;
        
        //public SecureString Password { get; set; } ???

        // PWD: geheim12!
    }
}

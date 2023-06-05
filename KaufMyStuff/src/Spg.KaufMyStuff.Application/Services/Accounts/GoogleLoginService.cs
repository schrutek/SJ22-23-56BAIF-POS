using Spg.KaufMyStuff.DomainModel.Dtos;
using Spg.KaufMyStuff.DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Services.Accounts
{
    public class GoogleLoginService : ILoginService
    {
        public (UserDto? userDto, bool isLoggedIn) CheckUserNameAndPwd(string userName, string password)
        {
            // Speziell für Login via AD
            return (default, true);
        }

        public void Register(RegisterDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

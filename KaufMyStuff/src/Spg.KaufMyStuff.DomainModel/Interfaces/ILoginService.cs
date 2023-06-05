using Spg.KaufMyStuff.DomainModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Interfaces
{
    public interface ILoginService
    {
        (UserDto? userDto, bool isLoggedIn) CheckUserNameAndPwd(string userName, string password);
        void Register(RegisterDto dto);
    }
}

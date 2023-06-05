using Spg.KaufMyStuff.DomainModel.Dtos;
using Spg.KaufMyStuff.DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Services.Accounts
{
    public class DbLoginService : ILoginService
    {
        public (UserDto? userDto, bool isLoggedIn) CheckUserNameAndPwd(string userName, string password)
        {
            // Speziell für Login via local DB
            // Logik hier, Daten kämen aus DB ...
            if (userName == "anna")
            {
                return (new UserDto()
                {
                    FirstName = "Anna",
                    LastName = "Theke",
                    EMail = "anna@theke.at",
                    Role = new RoleDto() { Key = "admin" }
                }, true);
            }
            return (default, false);
        }

        public void Register(RegisterDto dto)
        {
            // Initialisation
            // ...

            // Validation
            // ...

            // Act
            // ...

            // Save
            // ...
        }
    }
}

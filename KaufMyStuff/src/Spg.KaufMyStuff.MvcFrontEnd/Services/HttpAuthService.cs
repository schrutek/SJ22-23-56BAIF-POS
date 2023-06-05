using Bogus.Bson;
using Spg.KaufMyStuff.DomainModel.Helpers;
using Spg.KaufMyStuff.DomainModel.Dtos;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Spg.KaufMyStuff.MvcFrontEnd.Services
{
    public class HttpAuthService
    {
        private IHttpContextAccessor _contextAccessor;

        public HttpAuthService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserName()
        {
            string? json = _contextAccessor.HttpContext!.Request.Cookies["login_56baif"];

            if (!string.IsNullOrEmpty(json))
            {
                UserDto? dto = JsonSerializer.Deserialize<UserDto>(json);
                if (dto != null)
                {
                    return dto.EMail;
                }
            }
            return "nicht angemeldet";
        }

        public string IsLoggedIn
        {
            get
            {
                if (!string.IsNullOrEmpty(_contextAccessor.HttpContext!.Request.Cookies["login_56baif"]))
                {
                    return "";
                }
                return "disabled";
            }
        }
    }
}

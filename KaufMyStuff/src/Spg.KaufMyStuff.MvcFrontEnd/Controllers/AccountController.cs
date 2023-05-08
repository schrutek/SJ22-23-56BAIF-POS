using Microsoft.AspNetCore.Mvc;
using Spg.KaufMyStuff.DomainModel.Dtos;

namespace Spg.KaufMyStuff.MvcFrontEnd.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet()]
        public IActionResult Login()
        {
            return View(new LoginDto() { UserName = "asdads" });
        }

        [HttpPost()]
        public IActionResult Login(LoginDto dto)
        {
            //HttpContext.Response.Cookies.Append("login_56baif", dto.UserName);

            return View(dto);
        }
    }
}

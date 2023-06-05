using Microsoft.AspNetCore.Mvc;
using Spg.KaufMyStuff.DomainModel.Helpers;
using Spg.KaufMyStuff.DomainModel.Dtos;
using Spg.KaufMyStuff.DomainModel.Interfaces;
using System.Text.Json;
using Spg.KaufMyStuff.DomainModel.Exceptions;
using NuGet.Protocol;
using Microsoft.AspNetCore.Authentication;

namespace Spg.KaufMyStuff.MvcFrontEnd.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginService _loginService;

        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet()]
        public IActionResult Login()
        {
            return View(new LoginDto() { UserName = "anna" });
        }

        [HttpPost()]
        public IActionResult Login([FromForm()] LoginDto dto)
        {
            // TODO: Username mit DB überprüfen
            (UserDto? userDto, bool isLogedIn) = _loginService.CheckUserNameAndPwd(dto.UserName, "");
            if (isLogedIn)
            {
                userDto.Signature = HashHelper.CalcHash($"{userDto?.Fullname}{userDto?.Role.Key}");
                HttpContext.Response.Cookies.Append("login_56baif", JsonSerializer.Serialize(userDto), new CookieOptions()
                {
                    Expires = DateTime.Now.AddMinutes(3),
                });
                return RedirectToAction("Index", "Home");

                //HttpContext.SignInAsync();
            }
            return RedirectToAction("Error", "Account");
        }

        [HttpGet()]
        public IActionResult LogOut()
        {
            HttpContext.Response.Cookies.Delete("login_56baif");

            return RedirectToAction("Index", "Home");
        }

        [HttpGet()]
        public IActionResult Register()
        {
            return View(new RegisterDto() { BirthDate=DateTime.Now.AddYears(-14) });
        }

        [HttpPost()]
        public IActionResult Register([FromForm()] RegisterDto model)
        {
            // TODO: Dafür einen Service heranziehen
            if (model.EMail == "a@b.at")
            {
                ModelState.AddModelError("", "E-mail existioert bereits!");
            }
            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            // TODO:
            // * Daten in die DB schreiben
            // * Dafür aber einen Service verwenden
            try
            {
                throw new RegisterException("Absichtliche Exception!!!");
                _loginService.Register(model);
            }
            catch (RegisterException ex)
            {
                // TODO: Handle with Exceptions
                ModelState.AddModelError("", ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet()]
        public IActionResult Error()
        {
            return View();
        }
    }
}

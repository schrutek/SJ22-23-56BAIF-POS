using Microsoft.AspNetCore.Mvc;
using Spg.KaufMyStuff.DomainModel.Filters;
using Spg.KaufMyStuff.MvcFrontEnd.Models;
using Spg.KaufMyStuff.MvcFrontEnd.Services;
using System.Diagnostics;

namespace Spg.KaufMyStuff.MvcFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpAuthService _httpAuthService;

        public HomeController(ILogger<HomeController> logger, HttpAuthService httpAuthService)
        {
            _logger = logger;
            _httpAuthService = httpAuthService;
        }

        public IActionResult Index()
        {
            return View("Index", _httpAuthService.GetUserName());
        }

        // Admin JA, Guest Nein
        [AuthorisationFilter(RoleName = "admin")]
        public IActionResult Privacy()
        {
            return View("Privacy", _httpAuthService.GetUserName());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Forbidden()
        {
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spg.KaufMyStuff.Application.Services.Products;
using Spg.KaufMyStuff.DomainModel.Interfaces;
using Spg.KaufMyStuff.DomainModel.Models;

namespace Spg.KaufMyStuff.MvcFrontEnd.Controllers
{
    // https://localhost:1234/Product/Create/4711
    public class ProductController : Controller
    {
        private readonly IReadOnlyProductService _readOnlyProductService;

        public ProductController(IReadOnlyProductService readOnlyProductService)
        {
            _readOnlyProductService = readOnlyProductService;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> result = _readOnlyProductService
                .Load()
                .FilterNameContains("awesome")
                .FilterNameContains("ch")
                .FilterStockLimit(12)
                .FilterExpiryDate(DateTime.Now.AddDays(14))
                .Sort("name")
                .GetData();

            return View();
        }

        public IActionResult Create()
        {
            if (!ModelState.IsValid)
            {
                // Redirect (Error-Page)
            }

            List<SelectListItem> Names = new()
            {
                new SelectListItem("N01", "Name 1"),
                new SelectListItem("N02", "Name 2"),
                new SelectListItem("N03", "Name 3"),
                new SelectListItem("N04", "Name 4")
            };
            ViewBag.Names = Names;

            return View();
        }
    }
}

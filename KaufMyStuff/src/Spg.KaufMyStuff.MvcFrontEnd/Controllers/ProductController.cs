using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Spg.KaufMyStuff.MvcFrontEnd.Controllers
{
    // https://localhost:1234/Product/Create/4711
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
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

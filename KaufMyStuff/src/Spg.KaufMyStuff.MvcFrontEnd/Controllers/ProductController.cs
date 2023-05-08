using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spg.KaufMyStuff.Application.Cqrs.Products.Queries;
using Spg.KaufMyStuff.Application.Services.Products;
using Spg.KaufMyStuff.DomainModel.Dtos;
using Spg.KaufMyStuff.DomainModel.Interfaces;
using Spg.KaufMyStuff.DomainModel.Models;

namespace Spg.KaufMyStuff.MvcFrontEnd.Controllers
{
    // https://localhost:1234/Product/Create/4711
    public class ProductController : Controller
    {
        private readonly IReadOnlyProductService _readOnlyProductService;
        private readonly IMediator _mediator;

        public ProductController(IReadOnlyProductService readOnlyProductService, IMediator mediator)
        {
            _readOnlyProductService = readOnlyProductService;
            _mediator = mediator;
        }

        // https://localhost:1234/Product/Index
        public IActionResult Index()
        {
            IEnumerable<Product> result = _readOnlyProductService
                .Load()
                .FilterNameContains("awesome")
                //.FilterNameContains("ch")
                //.FilterStockLimit(12)
                //.FilterExpiryDate(DateTime.Now.AddDays(14))
                //.Sort("name")
                .GetData();

            return View(result);
        }

        // https://localhost:1234/Product/Details/Awesome%20Concrete%20Chicken
        [HttpGet()]
        public IActionResult Details(string name)
        {
            ProductDto result = _mediator.Send(new GetSingleProductRequest(name)).Result;

            return View(result);
        }

        // https://localhost:1234/Product/Create
        [HttpPost()]
        public IActionResult Create([FromBody()] CreateProductDto dto)
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

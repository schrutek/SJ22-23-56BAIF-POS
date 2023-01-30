using Spg.KaufMyStuff.Application.Services.Products;
using Spg.KaufMyStuff.DomainModel.Models;

IQueryable<Product> result = new ProductService().GetAll();

foreach (Product p in result.ToList())
{
    Console.WriteLine($"{p.Name} {p.Ean} {p.Material}");
}
using Microsoft.EntityFrameworkCore;
using Spg.KaufMyStuff.Application.Services;
using Spg.KaufMyStuff.Application.Services.Products;
using Spg.KaufMyStuff.DomainModel.Models;
using Spg.KaufMyStuff.Infrastructure;
using Spg.KaufMyStuff.Repositories;

DbContextOptionsBuilder options = new DbContextOptionsBuilder();
options.UseSqlite("Data Source=KaufMyStuff.db");

KaufMyStuffContext db = new KaufMyStuffContext(options.Options);
db.Database.EnsureDeleted();
db.Database.EnsureCreated();
db.Seed();

IQueryable<Product> result = new ProductService(new RepositoryBase<Product>(db), new RepositoryBase<Product>(db), new DateTimeService()).GetAll();

foreach (Product p in result.ToList())
{
    Console.WriteLine($"{p.Name} {p.Ean} {p.Material}");
}
using Microsoft.EntityFrameworkCore;
using Spg.KaufMyStuff.DomainModel.Models;
using Spg.KaufMyStuff.Infrastructure;

namespace Spg.KaufMyStuff.Repositories
{
    public class ProductRepository
    {
        public IQueryable<Product> GetAll()
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            options.UseSqlite("Data Source=KaufMyStuff.db");

            KaufMyStuffContext db = new KaufMyStuffContext(options.Options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            db.Seed();

            return db.Products;
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Spg.KaufMyStuff.DomainModel.Models;
using Spg.KaufMyStuff.Infrastructure;

namespace Spg.KaufMyStuff.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly KaufMyStuffContext _db;

        public ProductRepository(KaufMyStuffContext db)
        {
            _db = db;
        }

        public void Create(Product newProduct)
        {
            
        }

        public IQueryable<Product> GetAll()
        {
            return null;
        }
    }
}
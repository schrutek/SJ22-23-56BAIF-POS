using Spg.KaufMyStuff.DomainModel.Models;

namespace Spg.KaufMyStuff.Repositories
{
    public interface IProductRepository
    {
        void Create(Product newProduct);

        IQueryable<Product> GetAll();
    }
}

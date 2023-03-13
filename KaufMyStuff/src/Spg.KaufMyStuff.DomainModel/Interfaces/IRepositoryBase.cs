using Spg.KaufMyStuff.DomainModel.Models;

namespace Spg.KaufMyStuff.DomainModel.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        void Create(TEntity newProduct);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Interfaces
{
    public interface IReadOnlyRepositoryBase<TEntity>
    {
        TEntity? GetByPK<TKey>(TKey pk);
        IQueryable<TEntity> GetAll();

        T? GetByGuid<T>(Guid guid) where T : class, IFindableByGuid;
        T? GetByEMail<T>(string eMail) where T : class, IFindableByEMail;
    }
}

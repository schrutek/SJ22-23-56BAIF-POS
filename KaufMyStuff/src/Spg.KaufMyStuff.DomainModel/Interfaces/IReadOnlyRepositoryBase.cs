using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Interfaces
{
    public interface IReadOnlyRepositoryBase<TEntity>
    {
        TEntity? GetByPK<TKey>(TKey pk);
        T? GetByGuid<T>(Guid guid) where T : class, IFindableByGuid;
        T? GetByEMail<T>(string eMail) where T : class, IFindableByEMail;

        IQueryable<TEntity> GetAll(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeNavigationProperty = "",
            int? skip = null,
            int? take = null);

        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeNavigationProperty = "",
            int? skip = null,
            int? take = null);
    }
}
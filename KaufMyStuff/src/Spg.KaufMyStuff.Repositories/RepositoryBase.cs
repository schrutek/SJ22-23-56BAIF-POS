using Microsoft.EntityFrameworkCore;
using Spg.KaufMyStuff.DomainModel.Exceptions;
using Spg.KaufMyStuff.DomainModel.Interfaces;
using Spg.KaufMyStuff.Infrastructure;

namespace Spg.KaufMyStuff.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>, IReadOnlyRepositoryBase<TEntity>
        where TEntity : class
    {
        private readonly KaufMyStuffContext _db;

        public RepositoryBase(KaufMyStuffContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <remarks>
        /// Lorem ipsum...
        /// </remarks>
        /// <param name="newEntity">Beinhaltet die daten für ein neues Produkt.</param>
        /// <exception cref="RepositoryCreateException">Wird geworfen, wenn die datenbank fehlt.</exception>
        public void Create(TEntity newEntity)
        {
            DbSet<TEntity> set = _db.Set<TEntity>();
            set.Add(newEntity); // INSERT INTO
            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new RepositoryCreateException("Save ist fehlgeschlagen!", ex);
            }
        }

        public int Update(TEntity newEntity)
        {
            DbSet<TEntity> set = _db.Set<TEntity>();
            set.Update(newEntity);  // UPDATE ... WHERE Name='asdad'
            try
            {
                return _db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new RepositoryCreateException("Update ist fehlgeschlagen!", ex);
            }
        }

        public TEntity? GetByPK<TKey>(TKey pk)
        {
            return _db.Set<TEntity>().Find(pk);
        }

        public T? GetByGuid<T>(Guid guid) where T : class, IFindableByGuid
        {
            return _db.Set<T>().SingleOrDefault(e => e.Guid == guid);
        }

        public T? GetByEMail<T>(string eMail) where T : class, IFindableByEMail
        {
            return _db.Set<T>().SingleOrDefault(e => e.EMail == eMail);
        }

        public IQueryable<TEntity> GetAll()
        {
            return null;
        }
    }
}
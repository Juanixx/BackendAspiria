using Contratos.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositorios.Database
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
      where T : class
    {
        protected ApplicationDbContext _entities;
        protected readonly IDbSet<T> _dbset;

        public GenericRepository(ApplicationDbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public void AssignDbContext(ApplicationDbContext context)
        {
            _entities = context;
        }

        public virtual IEnumerable<T> GetAll()
        {

            return _dbset.AsEnumerable<T>();
        }

        public async Task<T> FindSingleByAsync(Expression<Func<T, bool>> predicate)
        {

            T query = await _dbset.Where(predicate).FirstOrDefaultAsync();
            return query;
        }

        public async Task<T> FindSingleByAndIncludeEntities(Expression<Func<T, bool>> predicate, string[] entities)
        {
            IQueryable<T> query = _dbset.Where(predicate);
            foreach (var param in entities)
            {
                query = query.Include(param);
            }
            var result = await query.FirstOrDefaultAsync();

            return result;
        }

        public virtual T Add(T entity)
        {
            return _dbset.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return _dbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}

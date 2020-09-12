using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contratos.Interfaces.Repositorios
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<T> FindSingleByAsync(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}

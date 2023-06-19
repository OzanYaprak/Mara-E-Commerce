using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public interface IRepository<T>
    {
        public IQueryable<T> GetAll();
        public IQueryable<T> FindAll(Expression<Func<T, bool>> expression);
        Task<T> GetByAsync(Expression<Func<T,bool>> expression);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task UpdateAsync(T entity, params Expression<Func<T,object>>[] expressions); //Object T nin objesi oluyor yani T Product, object ise ProductName olabilir.
        Task DeleteAsync(T entity);

    }
}
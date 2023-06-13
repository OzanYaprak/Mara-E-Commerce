using DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public class SQLRepository<T> : IRepository<T> where T : class // where T : class yani T class olmak zorunda
    {
        private readonly SQLContext context;

        public SQLRepository(SQLContext _context)
        {
            context = _context;
        }

        public void Add(T entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public T GetBy(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().FirstOrDefault(expression);
        }

        public void Update(T entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }

        public void Update(T entity, params Expression<Func<T, object>>[] expressions)
        {
            if (expressions.Any()) foreach (Expression<Func<T, object>> expression in expressions) context.Entry(entity).Property(expression).IsModified=true;
            else context.Update(entity);
            context.SaveChanges();
        }
    }
}

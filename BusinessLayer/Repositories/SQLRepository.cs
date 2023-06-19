using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public async Task<T> GetByAsync(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task UpdateAsync(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity, params Expression<Func<T, object>>[] expressions)
        {
            if (expressions.Any()) foreach (Expression<Func<T, object>> expression in expressions) context.Entry(entity).Property(expression).IsModified = true;
            else context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}

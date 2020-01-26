using LZRStatsApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LZRStatsApi.Repositories.Common
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected LzrStatsContext RepositoryContext { get; set; }

        public RepositoryBase(LzrStatsContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await RepositoryContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<IList<T>> GetByAsync(Expression<Func<T, bool>> expression)
        {
            return await RepositoryContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

        public T GetById(int id)
        {
            return RepositoryContext.Set<T>().Find(id);
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }
    }
}

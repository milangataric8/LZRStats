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

        public async Task<T> GetSingleByAsync(Expression<Func<T, bool>> expression)
        {
            return await RepositoryContext.Set<T>().Where(expression).AsNoTracking().SingleOrDefaultAsync();
        }

        public T GetById(int id)
        {
            return RepositoryContext.Set<T>().Find(id);
        }

        public async Task CreateAsync(T entity)
        {
            await RepositoryContext.Set<T>().AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => RepositoryContext.Set<T>().Update(entity));
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => RepositoryContext.Set<T>().Remove(entity));
        }

        public async Task SaveChangesAsync()
        {
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task AddOrUpdateAsync(T entity)
        {
            if ((int)entity.GetType().GetProperty("Id").GetValue(entity, null) == 0)
                await CreateAsync(entity);
            else
                await UpdateAsync(entity);

        }
    }
}

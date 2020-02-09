using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LZRStatsApi.Repositories.Common
{
    public interface IRepositoryBase<T>
    {
        Task<IList<T>> GetAllAsync();
        Task<IList<T>> GetByAsync(Expression<Func<T, bool>> expression);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}

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
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

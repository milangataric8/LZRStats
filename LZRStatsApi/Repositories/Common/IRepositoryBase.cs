using System;
using System.Linq;
using System.Linq.Expressions;

namespace LZRStatsApi.Repositories.Common
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetBy(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

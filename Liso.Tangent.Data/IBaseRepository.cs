using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;

namespace Liso.Tangent
{
    public interface IBaseRepository<TEntity>
    {
        Task<bool> CreateAsync(TEntity entity);

        Task<bool> CreateListAsync(IEnumerable<TEntity> entityList);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByQueryAsync(Expression<Func<TEntity, bool>> expression);

        Task<IEnumerable<TEntity>> GetAllByQueryAsync(Expression<Func<TEntity, bool>> expression);

        Task<bool> DeleteAsync(TEntity entity);

        Task<bool> UpdateAsync(TEntity entity);
    }
}

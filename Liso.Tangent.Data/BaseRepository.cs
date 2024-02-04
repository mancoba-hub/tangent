using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Liso.Tangent
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        #region Properties

        protected TangentContext TangentContext { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository"/> class.
        /// </summary>
        /// <param name="tangentContext"></param>
        protected BaseRepository(TangentContext tangentContext)
        {
            TangentContext = tangentContext;
        }

        #endregion

        #region Implemented Members

        /// <summary>
        /// Creates the entity asynchronously
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(TEntity entity)
        {
            await TangentContext.Set<TEntity>().AddAsync(entity);
            return await Task.FromResult(true);
        }

        /// <summary>
        /// Creates the entity list asynchronously
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public async Task<bool> CreateListAsync(IEnumerable<TEntity> entityList)
        {
            await TangentContext.Set<TEntity>().AddRangeAsync(entityList);
            return await Task.FromResult(true);
        }

        /// <summary>
        /// Deletes the entity asynchronously
        /// </summary>
        /// <param name="entity"></param>
        public async Task<bool> DeleteAsync(TEntity entity)
        {
            TangentContext.Set<TEntity>().Remove(entity);
            return await Task.FromResult(true);
        }

        /// <summary>
        /// Gets all entities asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await TangentContext.Set<TEntity>().AsNoTracking().ToArrayAsync();
        }

        /// <summary>
        /// Gets all by query asynchronously
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllByQueryAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await TangentContext.Set<TEntity>().Where(expression).AsNoTracking().ToArrayAsync();
        }

        /// <summary>
        /// Gets all entities by query or filter asynchronously
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<TEntity> GetByQueryAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await TangentContext.Set<TEntity>().Where(expression).AsNoTracking().FirstOrDefaultAsync();
        }

        /// <summary>
        /// Updates the entity asynchronously
        /// </summary>MO
        /// <param name="entity"></param>
        public async Task<bool> UpdateAsync(TEntity entity)
        {
            TangentContext.Set<TEntity>().Update(entity);
            return await Task.FromResult(true);
        }

        #endregion
    }
}

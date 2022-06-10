namespace Azox.Services
{
    using Azox.Data;
    using Azox.DomainModel;

    using Microsoft.Extensions.Caching.Memory;

    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public abstract partial class EntityBaseService<TEntity> :
        IEntityService<TEntity>
        where TEntity : class, IEntity
    {
        #region Utilities

        private async Task<IQueryable<TEntity>> GetAllAsync()
        {
            string cacheKey = $"{typeof(TEntity).FullName}.all-async";

            return await _unitOfWork.Cache.GetOrCreateAsync(cacheKey, async (entry) =>
            {
                return await ((IRepositoryInternal<TEntity>)EntityRepository).GetAllAsync();
            });
        }

        #endregion Utilities

        #region Methods

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return (await GetAllAsync()).Any(expression);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression)
        {
            return (await GetAllAsync()).Count(expression);
        }

        public async Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> expression)
        {
            return (await GetAllAsync()).Where(expression);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            return (await GetAllAsync()).FirstOrDefault(expression);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await EntityRepository.GetByIdAsync(id);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            return (await GetAllAsync()).SingleOrDefault(expression);
        }

        #endregion Methods
    }
}

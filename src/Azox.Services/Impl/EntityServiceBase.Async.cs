namespace Azox.Services
{
    using Azox.DomainModel;

    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public abstract partial class EntityServiceBase<TEntity> :
        IEntityService<TEntity>
        where TEntity : class, IEntity
    {
        #region Methods

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await EntityRepository.AnyAsync(expression);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await EntityRepository.CountAsync(expression);
        }

        public async Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await EntityRepository.FilterAsync(expression);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await EntityRepository.FirstOrDefaultAsync(expression);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await EntityRepository.GetByIdAsync(id);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await EntityRepository.SingleOrDefaultAsync(expression);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await UnitOfWork.SaveChangesAsync();
        }

        #endregion Methods
    }
}

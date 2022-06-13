namespace Azox.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public partial interface IEntityService<TEntity>
    {
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 
        /// </summary>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 
        /// </summary>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 
        /// </summary>
        Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 
        /// </summary>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 
        /// </summary>
        Task<int> SaveChangesAsync();

        #endregion Methods
    }
}

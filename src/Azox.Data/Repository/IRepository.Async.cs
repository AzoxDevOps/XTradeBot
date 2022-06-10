namespace Azox.Data
{
    using Azox.DomainModel;

    using System.Linq.Expressions;

    /// <summary>
    /// 
    /// </summary>
    public partial interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        #region ReadOnly Methods

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

        #endregion ReadOnly Methods

        #region Insert

        /// <summary>
        /// 
        /// </summary>
        Task InsertAsync(TEntity entity);

        #endregion Insert
    }
}

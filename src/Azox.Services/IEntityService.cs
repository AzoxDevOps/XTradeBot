namespace Azox.Services
{
    using Azox.DomainModel;

    using System.Linq.Expressions;

    /// <summary>
    /// 
    /// </summary>
    public partial interface IEntityService<TEntity>:
        IService
        where TEntity : class, IEntity
    {
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        bool Any(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 
        /// </summary>
        int Count(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 
        /// </summary>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 
        /// </summary>
        TEntity GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression);

        #endregion Methods
    }
}
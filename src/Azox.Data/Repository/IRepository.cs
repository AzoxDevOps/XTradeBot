namespace Azox.Data
{
    using Azox.DomainModel;

    using System.Linq.Expressions;

    /// <summary>
    /// 
    /// </summary>
    public interface IRepository
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public partial interface IRepository<TEntity>:
        IRepository
        where TEntity : class, IEntity
    {
        #region ReadOnly Methods

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

        #endregion ReadOnly Methods

        #region Insert

        void Insert(TEntity entity);

        #endregion Insert

        #region Update

        void Update(TEntity entity);

        #endregion Update

        #region Delete

        void Delete(TEntity entity);

        #endregion Delete
    }
}
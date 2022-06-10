namespace Azox.Data
{
    using Azox.DomainModel;

    /// <summary>
    /// 
    /// </summary>
    internal interface IRepositoryInternal<TEntity> :
        IRepository<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// 
        /// </summary>
        Task<IQueryable<TEntity>> GetAllAsync();
    }
}

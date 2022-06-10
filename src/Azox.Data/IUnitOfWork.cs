namespace Azox.Data
{
    using Azox.DomainModel;

    using Microsoft.Extensions.Caching.Memory;

    /// <summary>
    /// 
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 
        /// </summary>
        IRepository<TEntity> GetRepository<TEntity>()
           where TEntity : class, IEntity;

        /// <summary>
        /// 
        /// </summary>
        int SaveChanges();

        /// <summary>
        /// 
        /// </summary>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// 
        /// </summary>
        IMemoryCache Cache { get; }
    }
}
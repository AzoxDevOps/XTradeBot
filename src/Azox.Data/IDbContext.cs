namespace Azox.Data
{
    using Azox.DomainModel;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// 
        /// </summary>
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        /// <summary>
        /// 
        /// </summary>
        int SaveChanges();

        /// <summary>
        /// 
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

namespace Azox.Data
{
    using Azox.Core.Reflection;

    using Microsoft.EntityFrameworkCore;

    using System.Reflection;

    /// <summary>
    /// 
    /// </summary>
    public abstract class DbContextBase<TDbContext> :
        DbContext,
        IDbContext
        where TDbContext : DbContext, IDbContext
    {
        #region Ctor

        public DbContextBase(DbContextOptions<TDbContext> options) :
            base(options)
        {
        }

        #endregion Ctor

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            IEnumerable<Assembly> mappingAssemblies = TypeFinder
                .FindClassesOf<IDbContext>()
                .Select(x => x.Assembly);

            foreach (Assembly mappingAssembly in mappingAssemblies)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(mappingAssembly);
            }

            base.OnModelCreating(modelBuilder);
        }

        #endregion Methods
    }
}

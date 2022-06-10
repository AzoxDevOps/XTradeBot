namespace Azox.Data
{
    using Azox.Data;
    using Azox.DomainModel;

    using Microsoft.Extensions.Caching.Memory;

    internal class UnitOfWork :
        IUnitOfWork
    {
        #region Fields

        private readonly IDbContext _dbContext;
        private readonly IMemoryCache _cache;
        private readonly Dictionary<string, IRepository> _repositories;

        #endregion Fields

        #region Ctor

        public UnitOfWork(
            IDbContext dbContext,
            IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _cache = memoryCache;
            _repositories = new();
        }

        #endregion Ctor

        #region Methods

        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class, IEntity
        {
            string entityTypeName = typeof(TEntity).FullName;

            if (!_repositories.TryGetValue(entityTypeName, out IRepository repository))
            {
                repository = new EfRepository<TEntity>(_dbContext);
                _repositories.Add(entityTypeName, repository);
            }

            return (IRepository<TEntity>)repository;
        }

        public int SaveChanges()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion Methods

        #region Properties

        public IMemoryCache Cache => _cache;

        #endregion Properties
    }
}

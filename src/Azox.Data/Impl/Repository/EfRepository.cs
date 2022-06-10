namespace Azox.Data
{
    using Azox.DomainModel;

    using Microsoft.EntityFrameworkCore;

    using System.Linq.Expressions;

    /// <summary>
    /// 
    /// </summary>
    internal partial class EfRepository<TEntity> :
        IRepository<TEntity>,
        IRepositoryInternal<TEntity>
        where TEntity : class, IEntity
    {
        #region Fields

        private readonly IDbContext _dbContext;
        private DbSet<TEntity> _entities;

        #endregion Fields

        #region Ctor

        public EfRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion Ctor

        #region ReadOnly Methods

        /// <summary>
        /// 
        /// </summary>
        public bool Any(Expression<Func<TEntity, bool>> expression) => Entities.Any(expression);


        /// <summary>
        /// 
        /// </summary>
        public int Count(Expression<Func<TEntity, bool>> expression) => Entities.Count(expression);

        /// <summary>
        /// 
        /// </summary>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression) => Entities.FirstOrDefault(expression);

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> expression) => Entities.Where(expression).ToList();

        /// <summary>
        /// 
        /// </summary>
        public TEntity GetById(int id) => Entities.Find(id);

        /// <summary>
        /// 
        /// </summary>
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression) => Entities.SingleOrDefault(expression);

        #endregion ReadOnly Methods

        #region Insert

        public void Insert(TEntity entity)
        {
            Entities.Add(entity);
        }

        #endregion Insert

        #region Update

        public void Update(TEntity entity)
        {
            Entities.Update(entity);
        }

        #endregion Update

        #region Delete

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }

        #endregion Delete

        #region GetAll

        public IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = Entities;

            if (typeof(IDeletableEntity).IsAssignableFrom(typeof(TEntity)))
            {
                query = query.Where(x => !((IDeletableEntity)x).IsDeleted);
            }

            return query.ToList().AsQueryable();
        }

        #endregion GetAll

        #region Properties

        protected DbSet<TEntity> Entities => _entities = _dbContext.Set<TEntity>();

        #endregion Properties
    }
}

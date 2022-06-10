namespace Azox.Services
{
    using Azox.Data;
    using Azox.DomainModel;

    using Microsoft.Extensions.Caching.Memory;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;


    /// <summary>
    /// 
    /// </summary>
    public abstract partial class EntityBaseService<TEntity> :
        IEntityService<TEntity>
        where TEntity : class, IEntity
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;

        #endregion Fields

        #region Ctor

        public EntityBaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion Ctor

        #region Utilities

        private IQueryable<TEntity> GetAll()
        {
            string cacheKey = $"{typeof(TEntity).FullName}.all";

            return _unitOfWork.Cache.GetOrCreate(cacheKey, (entry) =>
            {
                return ((IRepositoryInternal<TEntity>)EntityRepository).GetAll();
            });
        }

        #endregion Utilities

        #region Methods

        public bool Any(Expression<Func<TEntity, bool>> expression)
        {
            return GetAll().Any(expression);
        }

        public int Count(Expression<Func<TEntity, bool>> expression)
        {
            return GetAll().Count(expression);
        }

        public IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> expression)
        {
            return GetAll().Where(expression);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return GetAll().FirstOrDefault(expression);
        }

        public TEntity GetById(int id)
        {
            return EntityRepository.GetById(id);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return GetAll().SingleOrDefault(expression);
        }

        #endregion Methods

        #region Properties

        protected IRepository<TEntity> EntityRepository => _unitOfWork.GetRepository<TEntity>();

        protected IUnitOfWork UnitOfWork => _unitOfWork;

        #endregion Properties
    }
}
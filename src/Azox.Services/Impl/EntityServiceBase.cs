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
    public abstract partial class EntityServiceBase<TEntity> :
        IEntityService<TEntity>
        where TEntity : class, IEntity
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;

        #endregion Fields

        #region Ctor

        public EntityServiceBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion Ctor

        #region Methods

        public bool Any(Expression<Func<TEntity, bool>> expression)
        {
            return EntityRepository.Any(expression);
        }

        public int Count(Expression<Func<TEntity, bool>> expression)
        {
            return EntityRepository.Count(expression);
        }

        public IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> expression)
        {
            return EntityRepository.Filter(expression);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return EntityRepository.FirstOrDefault(expression);
        }

        public TEntity GetById(int id)
        {
            return EntityRepository.GetById(id);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return EntityRepository.SingleOrDefault(expression);
        }

        public int SaveChanges()
        {
            return UnitOfWork.SaveChanges();
        }

        #endregion Methods

        #region Properties

        protected IRepository<TEntity> EntityRepository => _unitOfWork.GetRepository<TEntity>();

        protected IUnitOfWork UnitOfWork => _unitOfWork;

        #endregion Properties
    }
}
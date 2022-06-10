namespace Azox.Data
{
    using Azox.DomainModel;

    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    internal partial class EfRepository<TEntity> :
        IRepository<TEntity>
        where TEntity : class, IEntity
    {
        #region ReadOnly Methods

        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression) =>
            await Entities.AnyAsync(expression);

        /// <summary>
        /// 
        /// </summary>
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression) =>
            await Entities.CountAsync(expression);

        /// <summary>
        /// 
        /// </summary>
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression) =>
            await Entities.FirstOrDefaultAsync(expression);

        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> expression) =>
            await Entities.Where(expression).ToListAsync();

        /// <summary>
        /// 
        /// </summary>
        public async Task<TEntity> GetByIdAsync(int id) =>
            await Entities.FindAsync(id);

        /// <summary>
        /// 
        /// </summary>
        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression) =>
            await Entities.SingleOrDefaultAsync(expression);

        #endregion ReadOnly Methods

        #region GetAll

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            IQueryable<TEntity> query = Entities;

            if (typeof(IDeletableEntity).IsAssignableFrom(typeof(TEntity)))
            {
                query = query.Where(x => !((IDeletableEntity)x).IsDeleted);
            }

            List<TEntity> result =  await query.ToListAsync();

            return result.AsQueryable();
        }

        #endregion GetAll

        #region Insert

        public async Task InsertAsync(TEntity entity)
        {
            await Entities.AddAsync(entity);
        }
        

        #endregion Insert
    }
}

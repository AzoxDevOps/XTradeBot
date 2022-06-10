namespace Azox.DomainModel
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class DeletableBasicEntityBase :
        BasicEntityBase,
        IDeletableEntity
    {
        #region Ctor

        protected DeletableBasicEntityBase() { }

        protected internal DeletableBasicEntityBase(
            string code,
            string name,
            string description) :
            base(code, name, description)
        {
        }

        #endregion Ctor

        #region Methods

        internal virtual void Delete()
        {
            IsDeleted = true;
            DeletionTime = DateTime.UtcNow;
            LastUpdatedTime = DateTime.UtcNow;
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsDeleted { get; protected internal set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? DeletionTime { get; protected internal set; }

        #endregion Properties
    }
}

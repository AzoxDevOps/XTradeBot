namespace Azox.DomainModel
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public abstract class DeletableTrackableEntityBase :
        TrackableEntityBase,
        IDeletableEntity
    {
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

namespace Azox.DomainModel
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public abstract class TrackableEntityBase :
        EntityBase,
        ITrackableEntity
    {
        #region Ctor

        protected TrackableEntityBase()
        {
            CreationTime = DateTime.UtcNow;
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime CreationTime { get; protected internal set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? LastUpdatedTime { get; protected internal set; }

        #endregion Properties
    }
}

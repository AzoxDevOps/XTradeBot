namespace Azox.DomainModel
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BasicEntityBase :
        TrackableEntityBase,
        IBasicEntity
    {
        #region Ctor

        protected BasicEntityBase() { }

        protected internal BasicEntityBase(
            string code,
            string name,
            string description)
        {
            Code = code;
            Name = name;
            Description = description;
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Description { get; set; }

        #endregion Properties
    }
}

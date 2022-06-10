namespace Azox.DomainModel
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 
    /// </summary>
    public abstract class EntityBase :
        IEntity
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        [Column(Order = 0)]
        public virtual int Id { get; protected internal set; }

        #endregion Properties
    }
}

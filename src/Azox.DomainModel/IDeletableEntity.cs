namespace Azox.DomainModel
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDeletableEntity
    {
        /// <summary>
        /// 
        /// </summary>
        bool IsDeleted { get; }

        /// <summary>
        /// 
        /// </summary>
        DateTime? DeletionTime { get; }
    }
}
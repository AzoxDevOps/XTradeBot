namespace Azox.DomainModel
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITrackableEntity
    {
        /// <summary>
        /// 
        /// </summary>
        DateTime CreationTime { get; }

        /// <summary>
        /// 
        /// </summary>
        DateTime? LastUpdatedTime { get; }
    }
}
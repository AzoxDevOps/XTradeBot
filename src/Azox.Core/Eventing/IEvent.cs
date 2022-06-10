namespace Azox.Core.Eventing
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// 
        /// </summary>
        void Invoke(object obj);

        /// <summary>
        /// 
        /// </summary>
        Task InvokeAsync(object obj, CancellationToken cancellationToken = default);
    }
}

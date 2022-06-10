namespace Azox.Core.Eventing
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEventContext
    {
        /// <summary>
        /// 
        /// </summary>
        void Invoke<TEvent>(object obj)
           where TEvent : IEvent;

        /// <summary>
        /// 
        /// </summary>
        Task InvokeAsync<TEvent>(object obj, CancellationToken cancellationToken = default)
            where TEvent : IEvent;
    }
}

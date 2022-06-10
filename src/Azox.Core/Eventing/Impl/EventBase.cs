namespace Azox.Core.Eventing
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class EventBase :
        IEvent
    {
        #region Ctor

        public EventBase(IServiceProvider serviceProvider)
        {
            Services = serviceProvider;
        }

        #endregion Ctor

        #region Methods

        public abstract void Invoke(object obj);

        public abstract Task InvokeAsync(object obj, CancellationToken cancellationToken = default);

        #endregion Methods

        #region Properties

        protected IServiceProvider Services { get; }

        #endregion Properties
    }
}

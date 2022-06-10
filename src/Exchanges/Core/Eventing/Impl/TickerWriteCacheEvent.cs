namespace Azox.XTradeBot.Exchange.Core.Eventing
{
    using Azox.Core.Eventing;

    using Microsoft.Extensions.Caching.Distributed;

    using System.Threading;
    using System.Threading.Tasks;

    internal class TickerWriteCacheEvent :
        EventBase,
        ITickerReceivedEvent
    {
        #region Fields

        private readonly IDistributedCache _cache;

        #endregion Fields

        #region Ctor

        public TickerWriteCacheEvent(IServiceProvider serviceProvider) :
            base(serviceProvider)
        {
            _cache = serviceProvider.GetRequiredService<IDistributedCache>();
        }

        #endregion Ctor

        #region Methods

        public override void Invoke(object obj)
        {

        }

        public override async Task InvokeAsync(object obj, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
        }

        #endregion Methods
    }
}

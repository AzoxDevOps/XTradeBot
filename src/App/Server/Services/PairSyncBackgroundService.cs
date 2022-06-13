namespace Azox.XTradeBot.App.Server.Services
{
    using Azox.Core.Extensions;
    using Azox.XTradeBot.App.Server.Workers;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PairSyncBackgroundService :
        BackgroundService
    {
        #region Fields

        private readonly PairSyncWorker _worker;

        #endregion Fields

        #region Ctor

        public PairSyncBackgroundService(
            IServiceProvider serviceProvider)
        {
            _worker = serviceProvider.Resolve<PairSyncWorker>();
        }

        #endregion Ctor

        #region Methods

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _worker.Run(stoppingToken);
        }

        #endregion Methods
    }
}

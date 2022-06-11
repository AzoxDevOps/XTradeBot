namespace Azox.XTradeBot.Exchange.Core.Workers
{
    using Azox.XTradeBot.Exchange.Core.Clients;
    using Azox.XTradeBot.Exchange.Core.Configs;
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public class PairSyncWorker :
        BackgroundService
    {
        #region Fields

        private readonly IExchangeClient _exchangeClient;
        private readonly ExchangeConfig _exchangeConfig;

        #endregion Fields

        #region Ctor

        public PairSyncWorker(
            IExchangeClient exchangeClient,
            ExchangeConfig exchangeConfig)
        {
            _exchangeClient = exchangeClient;
            _exchangeConfig = exchangeConfig;
        }

        #endregion Ctor

        #region Methods

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var response = await _exchangeClient.ApiClient.GetSpotMarketSymbols(stoppingToken);
                if (response.Success)
                {
                    foreach (var item in response.Data)
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(item));
                    }
                }

                await Task.Delay(TimeSpan.FromMinutes(_exchangeConfig.PairSyncInMin), stoppingToken);
            }
        }

        #endregion Methods
    }
}

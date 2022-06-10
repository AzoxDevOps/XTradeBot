namespace Azox.XTradeBot.App.Binance.Clients
{
    using Azox.XTradeBot.App.Binance.Options;
    using Azox.XTradeBot.Exchange.Core.Clients;

    internal partial class ExchangeApiClient :
        ExchangeApiClientBase
    {
        #region Ctor

        public ExchangeApiClient()
        {
            SpotOptions = ExchangeApiClientOptions.DefaultSpotOptions;
        }

        #endregion Ctor
    }
}
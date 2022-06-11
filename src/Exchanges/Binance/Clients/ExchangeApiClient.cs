namespace Azox.XTradeBot.App.Binance.Clients
{
    using Azox.XTradeBot.App.Binance.Options;
    using Azox.XTradeBot.Exchange.Core.Clients;
    using Azox.XTradeBot.Exchange.Core.Configs;

    internal partial class ExchangeApiClient :
        ExchangeApiClientBase
    {
        #region Ctor

        public ExchangeApiClient(ExchangeConfig config) :
            base(config)
        {
            SpotOptions = ExchangeApiClientOptions.DefaultSpotOptions;
        }

        #endregion Ctor

        #region Parse Response Error

        protected override ApiResponseError ParseApiResponseError(string response)
        {
            return base.ParseApiResponseError(response);
        }

        #endregion Parse Response Error
    }
}
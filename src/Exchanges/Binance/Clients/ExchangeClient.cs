namespace Azox.XTradeBot.App.Binance.Clients
{
    using Azox.XTradeBot.Exchange.Core.Clients;
    using Azox.XTradeBot.Exchange.Core.Configs;

    /// <summary>
    /// 
    /// </summary>
    internal class ExchangeClient :
        ExchangeClientBase
    {
        #region Ctor

        public ExchangeClient(ExchangeConfig config)
        {
            ApiClient = new ExchangeApiClient(config);
            WebSocketClient = new ExchangeWebSocketClient();
        }

        #endregion Ctor
    }
}

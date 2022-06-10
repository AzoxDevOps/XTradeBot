namespace Azox.XTradeBot.App.Binance.Clients
{
    using Azox.XTradeBot.Exchange.Core.Clients;

    /// <summary>
    /// 
    /// </summary>
    internal class ExchangeClient :
        ExchangeClientBase
    {
        #region Ctor

        public ExchangeClient()
        {
            ApiClient = new ExchangeApiClient();
            WebSocketClient = new ExchangeWebSocketClient();
        }

        #endregion Ctor
    }
}

namespace Azox.XTradeBot.Exchange.Core.Clients
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ExchangeClientBase :
        IExchangeClient
    {
        #region Properties

        public IExchangeApiClient ApiClient { get; protected set; }

        public IExchangeWebSocketClient WebSocketClient { get; protected set; }

        #endregion Properties
    }
}

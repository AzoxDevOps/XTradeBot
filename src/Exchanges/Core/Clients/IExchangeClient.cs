namespace Azox.XTradeBot.Exchange.Core.Clients
{
    /// <summary>
    /// 
    /// </summary>
    public interface IExchangeClient
    {
        /// <summary>
        /// 
        /// </summary>
        IExchangeApiClient ApiClient { get; }

        /// <summary>
        /// 
        /// </summary>
        IExchangeWebSocketClient WebSocketClient { get; }
    }
}

namespace Azox.XTradeBot.Exchange.Core.Clients
{
    using Azox.XTradeBot.Exchange.Core.Options;

    using RestSharp;

    /// <summary>
    /// 
    /// </summary>
    public abstract partial class ExchangeApiClientBase
    {
        #region Fields

        #endregion Fields

        #region Properties

        protected IExchangeApiClientOptions SpotOptions { get; set; }

        #endregion Properties
    }
}

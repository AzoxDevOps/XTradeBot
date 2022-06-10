namespace Azox.XTradeBot.App.Binance.Options
{
    using Azox.XTradeBot.Exchange.Core.Options;

    public class ExchangeApiClientOptions :
        IExchangeApiClientOptions
    {
        #region Fields

        private static IExchangeApiClientOptions _spotOptions;

        #endregion Fields

        #region Ctor

        private ExchangeApiClientOptions(Uri baseAddress)
        {
            BaseAddress = baseAddress;
        }

        #endregion Ctor

        #region Methods

        public static IExchangeApiClientOptions DefaultSpotOptions
        {
            get
            {
                if (_spotOptions == null)
                {
                    _spotOptions = new ExchangeApiClientOptions(new("https://api.binance.com"));
                }
                return _spotOptions;
            }
        }

        #endregion Methods

        #region Properties

        public Uri BaseAddress { get; }

        #endregion Properties
    }
}

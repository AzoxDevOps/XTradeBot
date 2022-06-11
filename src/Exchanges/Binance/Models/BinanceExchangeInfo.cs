namespace Azox.XTradeBot.App.Binance.Models
{
    using Azox.XTradeBot.Exchange.Shared.Models;

    internal class BinanceExchangeInfo
    {
        public BinanceSymbolInfo[] Symbols { get; set; }

        #region Nested

        internal class BinanceSymbolInfo :
            IMarketSymbol
        {
            public string BaseAsset { get; set; }

            public string QuoteAsset { get; set; }
        }

        #endregion Nested
    }
}

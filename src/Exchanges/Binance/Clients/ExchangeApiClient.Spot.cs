namespace Azox.XTradeBot.App.Binance.Clients
{
    using Azox.XTradeBot.App.Binance.Models;
    using Azox.XTradeBot.Exchange.Core.Clients;
    using Azox.XTradeBot.Exchange.Shared.Models;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;

    internal partial class ExchangeApiClient
    {
        #region Get Market Symbols

        protected override ApiRequest GetMarketSymbolRequest()
        {
            ApiRequest request = new ApiRequest("/api/v3/exchangeInfo");

            return request;
        }

        protected override IEnumerable<IMarketSymbol> ParseMarketSymbols(JToken token)
        {
            try
            {
                BinanceExchangeInfo exchangeInfo = token.ToObject<BinanceExchangeInfo>();

                return exchangeInfo.Symbols;
            }
            catch
            {
                return Enumerable.Empty<BinanceExchangeInfo.BinanceSymbolInfo>();
            }
        }

        #endregion Get Market Symbols
    }
}

namespace Azox.XTradeBot.Exchange.Core.Clients
{
    using Azox.XTradeBot.Exchange.Core.Options;
    using Azox.XTradeBot.Exchange.Shared.Models;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// 
    /// </summary>
    public abstract partial class ExchangeApiClientBase
    {
        #region Fields

        #endregion Fields

        #region Get Market Symbols

        protected abstract ApiRequest GetMarketSymbolRequest();

        protected abstract IEnumerable<IMarketSymbol> ParseMarketSymbols(JToken token);

        public async Task<ApiResponse<IEnumerable<IMarketSymbol>>> GetSpotMarketSymbols(CancellationToken cancellationToken = default)
        {
            ApiResponse<JToken> response = await GetApiResponseAsync<JToken>(SpotOptions, GetMarketSymbolRequest(), cancellationToken);
            if (response.Success)
            {
                IEnumerable<IMarketSymbol> marketSymbols = ParseMarketSymbols(response.Data)
                    .Where(x => ExchangeConfig.AllowedQuoteAssets.Contains(x.QuoteAsset));
                
                return new(data: marketSymbols);
            }

            return new ApiResponse<IEnumerable<IMarketSymbol>>(error: response.Error.Value);
        }

        #endregion Get Market Symbols

        #region Properties

        protected IExchangeApiClientOptions SpotOptions { get; set; }

        #endregion Properties
    }
}

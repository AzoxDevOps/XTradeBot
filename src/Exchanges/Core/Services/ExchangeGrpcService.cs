namespace Azox.XTradeBot.Exchange.Core.Services
{
    using Azox.XTradeBot.Exchange.Core.Clients;
    using Azox.XTradeBot.Exchange.Shared.Models;
    using Azox.XTradeBot.Exchange.Shared.Services;

    /// <summary>
    /// 
    /// </summary>
    internal class ExchangeGrpcService :
        IExchangeGrpcService
    {
        #region Fields

        private readonly IExchangeClient _exchangeClient;

        #endregion Fields

        #region Ctor

        public ExchangeGrpcService(IExchangeClient exchangeClient)
        {
            _exchangeClient = exchangeClient;
        }

        #endregion Ctor

        #region Methods

        public async Task<MarketSymbol[]> GetSpotMarketSymbols(ProtoBuf.Grpc.CallContext callContext = default)
        {
            var response = await _exchangeClient.ApiClient.GetSpotMarketSymbols(callContext.CancellationToken);

            return response.Data.Select(x => new MarketSymbol
            {
                BaseAsset = x.BaseAsset,
                QuoteAsset = x.QuoteAsset
            }).ToArray();
        }

        #endregion Methods
    }
}

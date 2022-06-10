namespace Azox.XTradeBot.App.Server.Services
{
    using Azox.XTradeBot.App.Shared.Models;
    using Azox.XTradeBot.App.Shared.Services;
    using Azox.XTradeBot.DomainModel;
    using Azox.XTradeBot.Services;

    using Microsoft.Extensions.Caching.Distributed;

    using Newtonsoft.Json;

    /// <summary>
    /// 
    /// </summary>
    internal class TradePageService :
        ITradePageService
    {
        #region Fields

        private readonly IDistributedCache _cache;
        private readonly IExchangePairService _exchangePairService;

        #endregion Fields

        #region Ctor

        public TradePageService(
            IDistributedCache memoryCache,
            IExchangePairService exchangePairService)
        {
            _cache = memoryCache;
            _exchangePairService = exchangePairService;
        }

        #endregion Ctor

        #region Methods

        public async Task<ExchangePairModel[]> GetPairs(ProtoBuf.Grpc.CallContext context = default)
        {
            IList<ExchangePairModel> models = new List<ExchangePairModel>();
            IEnumerable<ExchangePair> pairs = await _exchangePairService.FilterAsync(x => !x.IsDeleted);

            foreach (ExchangePair exchangePair in pairs)
            {
                ExchangePairModel model = new ExchangePairModel
                {
                    Id = exchangePair.Id,
                    Selected = exchangePair.Exchange.Extended.DefaultSelectedPairId == exchangePair.Id,
                    Exchange = new ExchangeModel
                    {
                        Id = exchangePair.Exchange.Id,
                        Code = exchangePair.Exchange.Code,
                        Name = exchangePair.Exchange.Name
                    },
                    BaseAsset = new CurrencyModel
                    {
                        Id = exchangePair.BaseAsset.Id,
                        Code = exchangePair.BaseAsset.Code,
                        Name = exchangePair.BaseAsset.Name,
                        Extended = new CurrencyExtendedModel
                        {
                            IsMaster = exchangePair.BaseAsset.Extended.IsMaster,
                            IsStable = exchangePair.BaseAsset.Extended.IsStable
                        }
                    },
                    QuoteAsset = new CurrencyModel
                    {
                        Id = exchangePair.QuoteAsset.Id,
                        Code = exchangePair.QuoteAsset.Code,
                        Name = exchangePair.QuoteAsset.Name,
                        Extended = new CurrencyExtendedModel
                        {
                            IsMaster = exchangePair.QuoteAsset.Extended.IsMaster,
                            IsStable = exchangePair.QuoteAsset.Extended.IsStable
                        }
                    }
                };

                string cacheEntry = await _cache.GetStringAsync(exchangePair.SymbolFull, context.CancellationToken);
                if (!string.IsNullOrEmpty(cacheEntry))
                {
                    model.Ticker = JsonConvert.DeserializeObject<TickerModel>(cacheEntry);
                }
                else
                {

                }

                models.Add(model);
            }

            return models.ToArray();
        }

        #endregion Methods
    }
}

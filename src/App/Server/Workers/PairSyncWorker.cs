namespace Azox.XTradeBot.App.Server.Workers
{
    using Azox.XTradeBot.Exchange.Shared.Models;
    using Azox.XTradeBot.Exchange.Shared.Services;
    using Azox.XTradeBot.Services;
    using Grpc.Net.Client;
    using Grpc.Net.Client.Web;
    using ProtoBuf.Grpc.Client;
    using System.Collections.Concurrent;

    /// <summary>
    /// 
    /// </summary>
    internal class PairSyncWorker
    {
        #region Fields

        private readonly ICurrencyService _currencyService;
        private readonly IExchangeService _exchangeService;
        private readonly IExchangePairService _exchangePairService;

        private readonly ConcurrentDictionary<int, KeyValuePair<SemaphoreSlim, CancellationTokenSource>> _tokenSources;

        #endregion Fields

        #region Ctor

        public PairSyncWorker(
            ICurrencyService currencyService,
            IExchangeService exchangeService,
            IExchangePairService exchangePairService)
        {
            _currencyService = currencyService;
            _exchangeService = exchangeService;
            _exchangePairService = exchangePairService;

            _tokenSources = new();
        }

        #endregion Ctor

        #region Utilities

        private IExchangeGrpcService GetExchangeGrpcService(string endpoint)
        {
            GrpcWebHandler grpcWebHandler = new(GrpcWebMode.GrpcWeb, new HttpClientHandler());
            HttpClient httpClient = new(grpcWebHandler);

            GrpcChannel channel = GrpcChannel.ForAddress(
                endpoint,
                new GrpcChannelOptions
                {
                    HttpClient = httpClient,
                });

            return channel.CreateGrpcService<IExchangeGrpcService>();
        }

        private async Task RunWorkerAsync(DomainModel.Exchange exchange, SemaphoreSlim semaphore, CancellationToken stoppingToken)
        {
            IExchangeGrpcService exchangeGrpcService = GetExchangeGrpcService(exchange.Extended.ServiceEndpoint);

            MarketSymbol[] marketSymbols = await exchangeGrpcService.GetSpotMarketSymbols();

            foreach (MarketSymbol symbol in marketSymbols)
            {
                if (await _exchangePairService.AnyAsync(x => x.Exchange.Id == exchange.Id && x.BaseAsset.Code == symbol.BaseAsset && x.QuoteAsset.Code == symbol.QuoteAsset))
                {
                    continue;
                }

                DomainModel.Currency baseAsset = await _currencyService.SingleOrDefaultAsync(x => x.Code == symbol.BaseAsset)
                    ?? await _currencyService.Create(symbol.BaseAsset, symbol.BaseAsset, symbol.BaseAsset);

                DomainModel.Currency quoteAsset = await _currencyService.SingleOrDefaultAsync(x => x.Code == symbol.QuoteAsset)
                    ?? await _currencyService.Create(symbol.QuoteAsset, symbol.QuoteAsset, symbol.QuoteAsset);

                await _currencyService.SaveChangesAsync();

                await _exchangePairService.Create(exchange, baseAsset, quoteAsset, DomainModel.ExchangePairType.Spot);
                await _exchangePairService.SaveChangesAsync();
            }
        }

        #endregion Utilities

        #region Methods

        public async Task StartWorker(int exchangeId)
        {
            DomainModel.Exchange exchange = await _exchangeService
                .GetByIdAsync(exchangeId);

            if (exchange != null)
            {
                CancellationTokenSource cts = new();
                SemaphoreSlim semaphore = new(1, 1);
                _tokenSources[exchange.Id] = new KeyValuePair<SemaphoreSlim, CancellationTokenSource>(semaphore, cts);

                _ = Task.Factory.StartNew(() => RunWorkerAsync(exchange, semaphore, cts.Token), cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            }
        }

        public async Task Run(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                IEnumerable<DomainModel.Exchange> exchanges = await _exchangeService
                    .FilterAsync(x => !x.IsDeleted);

                Parallel.ForEach(exchanges, (exchange) =>
                {
                    CancellationTokenSource cts = new();
                    SemaphoreSlim semaphore = new(1, 1);
                    _tokenSources[exchange.Id] = new KeyValuePair<SemaphoreSlim, CancellationTokenSource>(semaphore, cts);

                    _ = Task.Factory.StartNew(() => RunWorkerAsync(exchange, semaphore, cts.Token), cancellationToken, TaskCreationOptions.LongRunning, TaskScheduler.Default);
                });

                await Task.Delay(TimeSpan.FromDays(1), cancellationToken);
            }
        }

        public void StopWorker(int exchangeId)
        {
            if (_tokenSources.TryGetValue(exchangeId, out var kvp))
            {
                kvp.Value.Cancel();
            }
        }

        #endregion Methods
    }
}

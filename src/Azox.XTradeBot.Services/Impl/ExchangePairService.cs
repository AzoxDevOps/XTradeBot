namespace Azox.XTradeBot.Services
{
    using Azox.Data;
    using Azox.Services;
    using Azox.XTradeBot.DomainModel;

    internal class ExchangePairService :
        EntityServiceBase<ExchangePair>,
        IExchangePairService
    {
        #region Ctor

        public ExchangePairService(IUnitOfWork unitOfWork) :
            base(unitOfWork)
        {

        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        public async Task<ExchangePair> Create(Exchange exchange, Currency baseAsset, Currency quoteAsset, ExchangePairType exchangePairType)
        {
            ExchangePair exchangePair = new(exchange, baseAsset, quoteAsset, exchangePairType);
            await UnitOfWork.GetRepository<ExchangePair>().InsertAsync(exchangePair);

            return exchangePair;
        }

        #endregion Methods
    }
}

namespace Azox.XTradeBot.Services
{
    using Azox.Services;
    using Azox.XTradeBot.DomainModel;

    /// <summary>
    /// 
    /// </summary>
    public interface IExchangePairService :
        IEntityService<ExchangePair>
    {
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        Task<ExchangePair> Create(Exchange exchange, Currency baseAsset, Currency quoteAsset, ExchangePairType exchangePairType);

        #endregion Methods
    }
}

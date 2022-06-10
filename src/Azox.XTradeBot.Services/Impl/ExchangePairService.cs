namespace Azox.XTradeBot.Services
{
    using Azox.Data;
    using Azox.Services;
    using Azox.XTradeBot.DomainModel;

    internal class ExchangePairService :
        EntityBaseService<ExchangePair>,
        IExchangePairService
    {
        #region Ctor

        public ExchangePairService(IUnitOfWork unitOfWork) :
            base(unitOfWork)
        {

        }

        #endregion Ctor
    }
}

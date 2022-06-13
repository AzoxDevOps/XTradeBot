namespace Azox.XTradeBot.Services
{
    using Azox.Data;
    using Azox.Services;
    using Azox.XTradeBot.DomainModel;

    internal class ExchangeService :
        EntityServiceBase<Exchange>,
        IExchangeService
    {
        #region Ctor

        public ExchangeService(IUnitOfWork unitOfWork) :
            base(unitOfWork)
        {

        }

        #endregion Ctor
    }
}

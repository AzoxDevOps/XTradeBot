namespace Azox.XTradeBot.Services
{
    using Azox.Data;
    using Azox.Services;
    using Azox.XTradeBot.DomainModel;

    internal class ExchangeService :
        EntityBaseService<Exchange>,
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

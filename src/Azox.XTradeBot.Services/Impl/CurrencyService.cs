namespace Azox.XTradeBot.Services
{
    using Azox.Data;
    using Azox.Services;
    using Azox.XTradeBot.DomainModel;

    internal class CurrencyService :
        EntityBaseService<Currency>,
        ICurrencyService
    {
        #region Ctor

        public CurrencyService(IUnitOfWork unitOfWork) :
            base(unitOfWork)
        {

        }

        #endregion Ctor
    }
}

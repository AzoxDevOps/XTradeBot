namespace Azox.XTradeBot.Services
{
    using Azox.Data;
    using Azox.Services;
    using Azox.XTradeBot.DomainModel;

    internal class CurrencyService :
        EntityServiceBase<Currency>,
        ICurrencyService
    {
        #region Ctor

        public CurrencyService(IUnitOfWork unitOfWork) :
            base(unitOfWork)
        {

        }

        #endregion Ctor

        #region Methods

        public async Task<Currency> Create(string code, string name, string description)
        {
            Currency currency = new(code, name, description);
            await UnitOfWork.GetRepository<Currency>().InsertAsync(currency);
            
            return currency;
        }

        #endregion Methods
    }
}

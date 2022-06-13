namespace Azox.XTradeBot.Services
{
    using Azox.Services;
    using Azox.XTradeBot.DomainModel;

    /// <summary>
    /// 
    /// </summary>
    public interface ICurrencyService :
        IEntityService<Currency>
    {
        /// <summary>
        /// 
        /// </summary>
        Task<Currency> Create(string code, string name, string description);
    }
}

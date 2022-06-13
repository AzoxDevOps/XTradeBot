namespace Azox.XTradeBot.App.Client.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILocalStorageService
    {
        /// <summary>
        /// 
        /// </summary>
        Task<string> GetItem(string key);

        /// <summary>
        /// 
        /// </summary>
        Task SetItem(string key, string value);

        /// <summary>
        /// 
        /// </summary>
        Task RemoveItem(string key);
    }
}

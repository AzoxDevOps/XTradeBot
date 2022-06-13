namespace Azox.XTradeBot.App.Client.Services
{
    using Microsoft.JSInterop;

    /// <summary>
    /// 
    /// </summary>
    internal class LocalStorageService :
        ILocalStorageService
    {
        #region Fields

        private readonly IJSRuntime _jsRuntime;

        #endregion Fields

        #region Ctor

        public LocalStorageService(IJSRuntime jSRuntime)
        {
            _jsRuntime = jSRuntime;
        }

        #endregion Ctor

        #region Methods

        public async Task<string> GetItem(string key)
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
        }

        public async Task SetItem(string key, string value)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, value);
        }

        public async Task RemoveItem(string key)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }

        #endregion Methods
    }
}

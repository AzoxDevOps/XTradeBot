namespace Azox.XTradeBot.App.Client.Services
{
    using Azox.XTradeBot.App.Shared.Models;

    /// <summary>
    /// 
    /// </summary>
    public interface IClientAuthenticationService
    {
        /// <summary>
        /// 
        /// </summary>
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    }
}
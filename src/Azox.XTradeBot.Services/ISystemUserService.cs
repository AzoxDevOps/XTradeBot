namespace Azox.XTradeBot.Services
{
    using Azox.Services;
    using Azox.XTradeBot.DomainModel;
    using Azox.XTradeBot.Services.Models;

    /// <summary>
    /// 
    /// </summary>
    public interface ISystemUserService :
        IEntityService<SystemUser>
    {
        /// <summary>
        /// 
        /// </summary>
        Task<SystemUser> GetByUsernameAsync(string username);

        /// <summary>
        /// 
        /// </summary>
        Task<SystemUserRegistrationResult> RegisterAsync(string username, string password);

        /// <summary>
        /// 
        /// </summary>
        Task<SystemUserLoginResult> LoginCheckAsync(string username, string password);
    }
}

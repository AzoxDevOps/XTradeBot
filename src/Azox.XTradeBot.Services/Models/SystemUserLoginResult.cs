namespace Azox.XTradeBot.Services.Models
{
    using Azox.XTradeBot.DomainModel;
    using System.Security.Claims;

    /// <summary>
    /// 
    /// </summary>
    public class SystemUserLoginResult
    {
        /// <summary>
        /// 
        /// </summary>
        public SystemUserLoginCheckResult Result { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Claim>? Claims { get; internal set; }

    }
}

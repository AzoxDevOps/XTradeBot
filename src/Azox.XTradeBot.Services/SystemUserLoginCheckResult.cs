namespace Azox.XTradeBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public enum SystemUserLoginCheckResult
    {
        /// <summary>
        /// 
        /// </summary>
        Succeeded = 1,
        /// <summary>
        /// 
        /// </summary>
        InactiveUser = 2,
        /// <summary>
        /// 
        /// </summary>
        LockedUser = 3,
        /// <summary>
        /// 
        /// </summary>
        InvalidUsernameOrPassword = 4
    }
}
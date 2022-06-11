namespace Azox.XTradeBot.Exchange.Core.Clients
{
    /// <summary>
    /// 
    /// </summary>
    public struct ApiResponseError
    {
        #region Ctor

        public ApiResponseError(
            int? code,
            string message)
        {
            Code = code;
            Message = message;
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int? Code { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; }

        #endregion Properties
    }
}

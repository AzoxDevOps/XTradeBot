namespace Azox.XTradeBot.Exchange.Core.Clients
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiResponse<TResponse>
    {
        #region Ctor

        public ApiResponse(TResponse? data)
        {
            Data = data;
        }

        public ApiResponse(int? errCode, string errMessage) :
            this(new ApiResponseError(errCode, errMessage))
        {
        }

        public ApiResponse(ApiResponseError error)
        {
            Error = error;
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public TResponse? Data { get; }

        /// <summary>
        /// 
        /// </summary>
        public ApiResponseError? Error { get; }

        /// <summary>
        /// 
        /// </summary>
        public bool Success => Error == null;

        #endregion Properties
    }
}

namespace Azox.XTradeBot.Exchange.Core.Clients
{
    using Azox.XTradeBot.Exchange.Core.Configs;
    using Azox.XTradeBot.Exchange.Core.Options;
    using RestSharp;
    using RestSharp.Serializers.NewtonsoftJson;

    /// <summary>
    /// 
    /// </summary>
    public abstract partial class ExchangeApiClientBase :
        IExchangeApiClient
    {
        #region Ctor

        protected ExchangeApiClientBase(ExchangeConfig config)
        {
            ExchangeConfig = config;
        }

        #endregion Ctor

        #region Parse Response Error

        protected virtual ApiResponseError ParseApiResponseError(string response)
        {
            return new ApiResponseError(null, response);
        }

        #endregion Parse Response Error

        #region Send Request

        protected virtual async Task<ApiResponse<TResponse>> GetApiResponseAsync<TResponse>(
            IExchangeApiClientOptions options,
            ApiRequest apiRequest,
            CancellationToken cancellationToken = default)
        {
            try
            {
                RestClient client = new RestClient(options.BaseAddress);
                client.UseNewtonsoftJson();

                RestRequest request = apiRequest.GetRequest();

                RestResponse<TResponse> response = await client.ExecuteAsync<TResponse>(request, cancellationToken);

                if (response.IsSuccessful)
                {
                    return new ApiResponse<TResponse>(response.Data);
                }
                else
                {
                    return new ApiResponse<TResponse>(ParseApiResponseError(response.Content));
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<TResponse>(null, ex.Message);
            }
        }

        #endregion Send Request

        #region Properties

        public ExchangeConfig ExchangeConfig { get; }

        #endregion Properties
    }
}

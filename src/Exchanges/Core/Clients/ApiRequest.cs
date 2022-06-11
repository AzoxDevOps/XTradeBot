namespace Azox.XTradeBot.Exchange.Core.Clients
{
    using RestSharp;

    /// <summary>
    /// 
    /// </summary>
    public struct ApiRequest
    {
        #region Ctor

        public ApiRequest(string endpoint)
        {
            Endpoint = endpoint;
        }

        #endregion Ctor

        #region Methods

        public RestRequest GetRequest()
        {
            RestRequest request = new RestRequest(Endpoint);

            return request;
        }

        #endregion Methods

        #region Properties

        public string Endpoint { get; }

        #endregion Properties
    }
}

namespace Azox.XTradeBot.Exchange.Core.Clients
{
    using Azox.XTradeBot.Exchange.Shared.Models;

    /// <summary>
    /// 
    /// </summary>
    public partial interface IExchangeApiClient
    {
        /// <summary>
        /// 
        /// </summary>
        Task<ApiResponse<IEnumerable<IMarketSymbol>>> GetSpotMarketSymbols(CancellationToken cancellationToken = default);
    }
}

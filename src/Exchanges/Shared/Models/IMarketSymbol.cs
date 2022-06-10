namespace Azox.XTradeBot.Exchange.Shared.Models
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMarketSymbol
    {
        /// <summary>
        /// 
        /// </summary>
        string BaseAsset { get; }

        /// <summary>
        /// 
        /// </summary>
        string QuoteAsset { get; }
    }
}

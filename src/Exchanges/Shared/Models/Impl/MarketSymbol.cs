namespace Azox.XTradeBot.Exchange.Shared.Models
{
    using ProtoBuf;

    /// <summary>
    /// 
    /// </summary>
    [ProtoContract]
    public class MarketSymbol :
        IMarketSymbol
    {
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(1)]
        public string BaseAsset { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(2)]
        public string QuoteAsset { get; set; }
    }
}

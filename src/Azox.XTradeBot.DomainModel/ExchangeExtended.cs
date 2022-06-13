namespace Azox.XTradeBot.DomainModel
{
    /// <summary>
    /// 
    /// </summary>
    public class ExchangeExtended
    {
        /// <summary>
        /// 
        /// </summary>
        public string ServiceEndpoint { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? DefaultSelectedPairId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PairSplitter { get; set; } = string.Empty;
    }
}

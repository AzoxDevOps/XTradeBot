namespace Azox.XTradeBot.Exchange.Core.Configs
{
    using Azox.Core.Configs;

    /// <summary>
    /// 
    /// </summary>
    public class ExchangeConfig :
        IConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public string[] AllowedQuoteAssets { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PairSplitter { get; set; }
    }
}

namespace Azox.XTradeBot.DomainModel
{
    using Azox.DomainModel;

    /// <summary>
    /// 
    /// </summary>
    public class ExchangePair :
        DeletableTrackableEntityBase
    {
        #region Ctor

        protected ExchangePair() { }

        protected internal ExchangePair(
            Exchange exchange,
            Currency baseAsset,
            Currency quoteAsset,
            ExchangePairType pairType)
        {
            Exchange = exchange;
            BaseAsset = baseAsset;
            QuoteAsset = quoteAsset;
            PairType = pairType;
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual Exchange? Exchange { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Currency? BaseAsset { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Currency? QuoteAsset { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ExchangePairType PairType { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string SymbolShort => $"{BaseAsset.Code}{Exchange.Extended.PairSplitter}{QuoteAsset.Code}";

        /// <summary>
        /// 
        /// </summary>
        public virtual string SymbolFull => $"{SymbolShort} {Exchange.Name} {PairType}";

        #endregion Properties
    }
}
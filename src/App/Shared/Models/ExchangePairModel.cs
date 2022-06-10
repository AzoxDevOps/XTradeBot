namespace Azox.XTradeBot.App.Shared.Models
{
    using ProtoBuf;

    [ProtoContract]
    public class ExchangePairModel :
        IProtoModel
    {
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(1)]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(2)]
        public ExchangeModel Exchange { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(3)]
        public CurrencyModel BaseAsset { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(4)]
        public CurrencyModel QuoteAsset { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(5)]
        public bool Selected { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(6)]
        public bool IsFavorite { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(7)]
        public TickerModel Ticker { get; set; }
    }
}

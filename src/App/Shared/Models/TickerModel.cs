namespace Azox.XTradeBot.App.Shared.Models
{
    using ProtoBuf;

    /// <summary>
    /// 
    /// </summary>
    [ProtoContract]
    public class TickerModel
    {
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(1)]
        public decimal LastPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(2)]
        public decimal Change { get; set; }
    }
}
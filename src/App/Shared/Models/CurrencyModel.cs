namespace Azox.XTradeBot.App.Shared.Models
{
    using ProtoBuf;

    /// <summary>
    /// 
    /// </summary>
    [ProtoContract]
    public class CurrencyModel :
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
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(3)]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(4)]
        public CurrencyExtendedModel Extended { get; set; }
    }
}
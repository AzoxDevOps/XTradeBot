namespace Azox.XTradeBot.App.Shared.Models
{
    using ProtoBuf;

    /// <summary>
    /// 
    /// </summary>
    [ProtoContract]
    public class CurrencyExtendedModel
    {
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(1)]
        public bool IsMaster { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(2)]
        public bool IsStable { get; set; }
    }
}
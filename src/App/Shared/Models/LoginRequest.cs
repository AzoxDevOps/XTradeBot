namespace Azox.XTradeBot.App.Shared.Models
{
    using ProtoBuf;

    /// <summary>
    /// 
    /// </summary>
    [ProtoContract]
    public class LoginRequest :
        IProtoModel
    {
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(1)]
        public string Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(2)]
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(3)]
        public string Token { get; set; }
    }
}

namespace Azox.XTradeBot.App.Shared.Models
{
    using ProtoBuf;

    /// <summary>
    /// 
    /// </summary>
    [ProtoContract]
    public class LoginResponse :
        IProtoModel
    {
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(1)]
        public bool Success { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(2)]
        public string Token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(3)]
        public string ErrMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(4)]
        public string Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(5)]
        public RoleLevel? RoleLevel { get; set; }
    }
}

namespace Azox.XTradeBot.App.Server.Configs
{
    using Azox.Core.Configs;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public class JwtConfig :
        IConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte[] SecretKeyBytes => Encoding.ASCII.GetBytes(SecretKey);
    }
}

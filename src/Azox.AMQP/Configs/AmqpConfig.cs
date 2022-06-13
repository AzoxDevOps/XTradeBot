namespace Azox.AMQP.Configs
{
    using Azox.Core.Configs;

    /// <summary>
    /// 
    /// </summary>
    internal class AmqpConfig :
        IConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Port { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string VirtualHost { get; set; }
    }
}

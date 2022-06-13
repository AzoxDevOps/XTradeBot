namespace Azox.AMQP.Models
{
    public class ConsumeRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string ExchangeName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ExchangeType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RoutingKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CancellationToken CancellationToken { get; set; } = default;
    }
}

namespace Azox.AMQP
{
    using Azox.AMQP.Models;
    using System;

    /// <summary>
    /// 
    /// </summary>
    public interface IAmqpService
    {
        /// <summary>
        /// 
        /// </summary>
        void Consume<T>(ConsumeRequest request, Action<T> onReceived);
    }
}

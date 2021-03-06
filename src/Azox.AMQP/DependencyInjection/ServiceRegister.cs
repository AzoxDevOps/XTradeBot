namespace Azox.AMQP.DependencyInjection
{
    using Azox.Core.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// 
    /// </summary>
    internal class ServiceRegister :
        IServiceRegister
    {
        /// <summary>
        /// 
        /// </summary>
        public void Register(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<IAmqpService, AmqpService>();
        }
    }
}

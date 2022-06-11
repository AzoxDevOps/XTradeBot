namespace Azox.Core.Eventing
{
    using Azox.Core.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal class ServiceRegister :
        IServiceRegister
    {
        public void Register(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSingleton<IEventContext, EventContext>();
        }
    }
}

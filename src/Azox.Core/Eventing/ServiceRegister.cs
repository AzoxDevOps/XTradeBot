namespace Azox.Core.Eventing
{
    using Azox.Core.DependencyInjection;

    using Microsoft.Extensions.DependencyInjection;

    internal class ServiceRegister :
        IServiceRegister
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton<IEventContext, EventContext>();
        }
    }
}

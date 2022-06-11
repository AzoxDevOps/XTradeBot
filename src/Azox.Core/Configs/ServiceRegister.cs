namespace Azox.Core.Configs
{
    using Azox.Core.DependencyInjection;
    using Azox.Core.Reflection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal class ServiceRegister :
        IServiceRegister
    {
        public void Register(IConfiguration configuration, IServiceCollection services)
        {
            foreach (IConfig config in TypeFinder.FindInstancesOf<IConfig>())
            {
                configuration
                    .GetSection(config.GetType().Name)
                    .Bind(config);

                services.AddSingleton(config.GetType(), config);
            }
        }
    }
}

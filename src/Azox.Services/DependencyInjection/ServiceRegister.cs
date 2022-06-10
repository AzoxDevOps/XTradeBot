namespace Azox.Services.DependencyInjection
{
    using Azox.Core.DependencyInjection;
    using Azox.Core.Reflection;

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
        public void Register(IServiceCollection services)
        {
            IEnumerable<Type> serviceInterfaceTypes = TypeFinder
                .FindInterfacesOf<IService>()
                .Where(x => !x.ContainsGenericParameters);

            foreach (Type serviceInterfaceType in serviceInterfaceTypes)
            {
                foreach (Type serviceType in TypeFinder.FindClassesOf(serviceInterfaceType))
                {
                    services.AddScoped(serviceInterfaceType, serviceType);
                    break;
                }
            }
        }
    }
}

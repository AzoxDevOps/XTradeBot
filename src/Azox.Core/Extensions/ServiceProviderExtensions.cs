namespace Azox.Core.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    using System;

    /// <summary>
    /// 
    /// </summary>
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static T Resolve<T>(this IServiceProvider serviceProvider)
        {
            return (T)Resolve(serviceProvider, typeof(T));
        }

        /// <summary>
        /// 
        /// </summary>
        public static object Resolve(this IServiceProvider serviceProvider, Type serviceType)
        {
            try
            {
                return serviceProvider.GetRequiredService(serviceType);
            }
            catch (InvalidOperationException)
            {
                return serviceProvider.CreateScope().ServiceProvider
                    .GetRequiredService(serviceType);
            }
        }
    }
}

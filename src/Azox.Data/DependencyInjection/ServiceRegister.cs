namespace Azox.Data.DependencyInjection
{
    using Azox.Core.DependencyInjection;
    using Azox.Data;

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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

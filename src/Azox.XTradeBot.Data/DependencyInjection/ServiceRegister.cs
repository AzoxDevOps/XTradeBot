namespace Azox.XTradeBot.Data.DependencyInjection
{
    using Azox.Core.DependencyInjection;
    using Azox.Data;

    using Microsoft.EntityFrameworkCore;
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
            services.AddDbContext<XTradeBotDbContext>((serviceProvider, options) =>
            {
                string connectionString = configuration
                    .GetConnectionString(nameof(XTradeBot));

                options.UseSqlServer(connectionString);
                options.UseLazyLoadingProxies();
            });

            services.AddScoped<IDbContext, XTradeBotDbContext>();
        }
    }
}

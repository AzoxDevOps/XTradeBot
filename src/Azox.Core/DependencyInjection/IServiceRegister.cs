namespace Azox.Core.DependencyInjection
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// 
    /// </summary>
    public interface IServiceRegister
    {
        /// <summary>
        /// 
        /// </summary>
        void Register(IConfiguration configuration, IServiceCollection services);
    }
}

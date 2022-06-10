namespace Azox.Core.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// 
    /// </summary>
    public interface IServiceRegister
    {
        /// <summary>
        /// 
        /// </summary>
        void Register(IServiceCollection services);
    }
}

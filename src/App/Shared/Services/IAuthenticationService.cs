namespace Azox.XTradeBot.App.Shared.Services
{
    using Azox.XTradeBot.App.Shared.Models;
    using ProtoBuf.Grpc;
    using System.ServiceModel;

    /// <summary>
    /// 
    /// </summary>
    [ServiceContract]
    public interface IAuthenticationService
    {
        /// <summary>
        /// 
        /// </summary>
        [OperationContract]
        Task<LoginResponse> LoginAsync(LoginRequest request, CallContext callContext = default);

        /// <summary>
        /// 
        /// </summary>
        [OperationContract]
        Task<LoginResponse> LoginWithTokenAsync(LoginRequest request, CallContext callContext = default);
    }
}

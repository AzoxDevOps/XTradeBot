namespace Azox.XTradeBot.App.Shared.Services
{
    using Azox.XTradeBot.App.Shared.Models;

    using System.ServiceModel;

    /// <summary>
    /// 
    /// </summary>
    [ServiceContract]
    public interface ITradePageService
    {
        /// <summary>
        /// 
        /// </summary>
        [OperationContract]
        Task<ExchangePairModel[]> GetPairs(ProtoBuf.Grpc.CallContext context = default);
    }
}

namespace Azox.XTradeBot.Exchange.Shared.Services
{
    using Azox.XTradeBot.Exchange.Shared.Models;
    using System.ServiceModel;

    /// <summary>
    /// 
    /// </summary>
    [ServiceContract]
    public interface IExchangeGrpcService
    {
        [OperationContract]
        Task<MarketSymbol[]> GetSpotMarketSymbols(ProtoBuf.Grpc.CallContext callContext = default);
    }
}

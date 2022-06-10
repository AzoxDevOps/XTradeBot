namespace Azox.XTradeBot.App.Binance
{
    using Azox.XTradeBot.App.Binance.Clients;
    using Azox.XTradeBot.Exchange.Core;
    using Azox.XTradeBot.Exchange.Core.Clients;

    class Program
    {
        static void Main(string[] args)
        {
            Startup startup = new(args);

            startup.OnConfigureServices += (builder) =>
            {
                builder.Services.AddSingleton<IExchangeClient, ExchangeClient>();
            };

            startup.OnConfigurePipelines += (app) =>
            {

            };

            startup.Run();
        }
    }
}



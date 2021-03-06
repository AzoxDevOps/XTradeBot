namespace Azox.XTradeBot.App.Client
{
    using Azox.XTradeBot.App.Client.Services;
    using Azox.XTradeBot.App.Shared.Services;

    using Grpc.Net.Client;
    using Grpc.Net.Client.Web;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Components.Web;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

    using ProtoBuf.Grpc.Client;

    class Program
    {
        static async Task Main(string[] args)
        {
            WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
            ConfigureServices(builder);
            WebAssemblyHost app = builder.Build();
            Configure(app);
            await app.RunAsync();
        }

        static void ConfigureServices(WebAssemblyHostBuilder builder)
        {
            builder.RootComponents.Add<App>(".root");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped<AuthenticationStateProvider, ClientAuthenticationService>();
            builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
            builder.Services.AddScoped<IClientAuthenticationService, ClientAuthenticationService>();

            builder.Services.AddSingleton<IAuthenticationService>(serviceProvider =>
            {
                GrpcWebHandler grpcWebHandler = new(GrpcWebMode.GrpcWeb, new HttpClientHandler());
                HttpClient httpClient = new(grpcWebHandler);

                GrpcChannel channel = GrpcChannel.ForAddress(
                    builder.HostEnvironment.BaseAddress,
                    new GrpcChannelOptions
                    {
                        HttpClient = httpClient,
                    });

                return channel.CreateGrpcService<IAuthenticationService>();
            });
            builder.Services.AddSingleton<ITradePageService>(serviceProvider =>
            {
                GrpcWebHandler grpcWebHandler = new(GrpcWebMode.GrpcWeb, new HttpClientHandler());
                HttpClient httpClient = new(grpcWebHandler);

                GrpcChannel channel = GrpcChannel.ForAddress(
                    builder.HostEnvironment.BaseAddress,
                    new GrpcChannelOptions
                    {
                        HttpClient = httpClient,
                    });

                return channel.CreateGrpcService<ITradePageService>();
            });
        }

        static void Configure(WebAssemblyHost app)
        {

        }
    }
}
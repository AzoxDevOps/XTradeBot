namespace Azox.XTradeBot.App.Server
{
    using Azox.Core.DependencyInjection;
    using Azox.Core.Reflection;
    using Azox.XTradeBot.App.Server.Services;

    using ProtoBuf.Grpc.Server;

    class Program
    {
        static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            WebApplication app = builder.Build();
            Configure(app);
            app.Run();
        }

        static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddCodeFirstGrpc();
            builder.Services.AddCors();
            builder.Services.AddMemoryCache();
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = builder.Configuration.GetConnectionString("Redis");
                options.InstanceName = "Server";
            });

            foreach (IServiceRegister serviceRegister in TypeFinder.FindInstancesOf<IServiceRegister>())
            {
                serviceRegister.Register(builder.Configuration, builder.Services);
            }
        }

        static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            app.UseGrpcWeb();
            app.MapFallbackToFile("index.html");

            app.MapGrpcService<TradePageService>()
                .EnableGrpcWeb()
                .RequireCors(options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });

        }
    }
}
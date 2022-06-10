namespace Azox.XTradeBot.Exchange.Core
{
    using Azox.Core.DependencyInjection;
    using Azox.Core.Reflection;
    using Azox.XTradeBot.Exchange.Core.Services;

    using ProtoBuf.Grpc.Server;

    public class Startup
    {
        #region Fields

        private readonly string[] _args;

        #endregion Fields

        #region Ctor

        public Startup(string[] args)
        {
            _args = args;
        }

        #endregion Ctor

        #region Events

        public event Action<WebApplicationBuilder> OnConfigureServices;

        public event Action<WebApplication> OnConfigurePipelines;

        #endregion Events

        #region Utilities

        private void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddCodeFirstGrpc();
            builder.Services.AddCors();
            builder.Services.AddMemoryCache();
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = builder.Configuration.GetConnectionString("Redis");
                options.InstanceName = "Exchange";
            });

            foreach (IServiceRegister serviceRegister in TypeFinder.FindInstancesOf<IServiceRegister>())
            {
                serviceRegister.Register(builder.Services);
            }

            OnConfigureServices?.Invoke(builder);
        }

        private void ConfigurePipelines(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            app.UseGrpcWeb();

            app.MapGrpcService<ExchangeGrpcService>()
                .EnableGrpcWeb()
                .RequireCors(options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });

            OnConfigurePipelines?.Invoke(app);
        }

        #endregion Utilities

        #region Methods

        public void Run()
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(_args);
            ConfigureServices(builder);
            WebApplication app = builder.Build();
            ConfigurePipelines(app);
            app.Run();
        }

        #endregion Methods
    }
}

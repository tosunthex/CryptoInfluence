using cointweety.Core;
using cointweety.Persistence;
using cointweety.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace cointweety
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICoinMarketCap, CoinMarketCapReposity>();
            services.AddTransient<ISolume, SolumeReposity>();
            services.AddTransient<ICoinSocialAnalysis, CoinSocialAnalysisReposity>();
            services.AddTransient<ICoinSocialMediaAddress, CoinSocialMediaAddressReposity>();
            services.AddTransient<ICoinTweet, CoinTweetReposity>();
            services.AddTransient<IJsonDeserialize, JsonDeserializerService>();
            services.AddTransient<ICoin, CoinReposity>();
            services.AddTransient<ITwitterAccount, TwitterAccountReposity>();
            services.AddTransient<ISocialStats, SocialStatsReposity>();
            services.AddMvc();
            
            services.Configure<MongoDbOptions>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });
            services.Configure<RestApiOptions>(options =>
            {
                options.CoinMarketCapApi = Configuration.GetSection("CryptoApiConnections:CoinMarketCap").Value;
                options.CryptoCompareApi = Configuration.GetSection("CryptoApiConnections:CryptoCompare").Value;
                options.SolumeApi = Configuration.GetSection("CryptoApiConnections:Solume").Value;
                options.CryptoCompareApiOld = Configuration.GetSection("CryptoApiConnections:CryptoCompareOld").Value;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    HotModuleReplacementEndpoint = "/dist/__webpack_hmr"
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}

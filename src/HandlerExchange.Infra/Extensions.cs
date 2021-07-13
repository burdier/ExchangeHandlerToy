using System;
using System.Net.Http;
using HandlerExchange.Infra.HttpServices;
using Microsoft.Extensions.DependencyInjection;

namespace HandlerExchange.Infra
{
    public static  class Extensions
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {

            services.AddHttpClient<CryptoService>(c => {
                c.BaseAddress = new Uri("https://pro-api.coinmarketcap.com");
                c.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY","your key");
            });
            services.AddScoped<IMarketApiService, MarketApiService>();
            return services;
        }
        public static bool isPositive(this decimal value) =>   value > 0;
    } 
}
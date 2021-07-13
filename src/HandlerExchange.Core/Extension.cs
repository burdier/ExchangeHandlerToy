using HandlerExchange.Core.Authorization;
using HandlerExchange.Core.DAL.Repositories;
using HandlerExchange.Core.Services;
using HandlerExchange.Core.Services.WebApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HandlerExchange.Core
{
    public static  class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInvestmentRepository,InvestmentRepository>();
            services.AddScoped<IInvestmentService,InvestmentService>();
            return services;
        }
    }
}
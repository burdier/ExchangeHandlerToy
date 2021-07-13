using System.Linq;
using System.Threading.Tasks;
using HandlerExchange.Core.Authorization;
using HandlerExchange.Core.Services.WebApi.Services;
using HandlerExchange.Shared.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace HandlerExchange.Api.Authorization
{
    public class JwtMiddleware
    {
       
            private readonly RequestDelegate _next;
            private readonly AppSettings _appSettings;

            public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
            {
                _next = next;
                _appSettings = appSettings.Value;
            }

            public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var userId = jwtUtils.ValidateToken(token);
                if (userId != null)
                {
                    // attach user to context on successful jwt validation
                    context.Items["User"] = await  userService.GetAsync(userId.Value);
                }

                await _next(context);
            }
    }
}
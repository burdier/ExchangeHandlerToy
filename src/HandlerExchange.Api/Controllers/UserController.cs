using System;
using System.Threading.Tasks;
using HandlerExchange.Core.Authorization;
using HandlerExchange.Core.DTO;
using HandlerExchange.Core.Services.WebApi.Services;
using HandlerExchange.Shared.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver.Core.Operations;

namespace HandlerExchange.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly AppSettings _appSettings;

        public UsersController(
            IUserService userService,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async  Task<IActionResult> Authenticate(AuthenticateRequestDto model)
        {
            var response = await  _userService.AuthenticateAsync(model);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async  Task<IActionResult> Register(RegisterRequestDto model)
        {
            await  _userService.RegisterAsync(model);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _userService.BrowseAsync());

        [HttpGet("{id}")]
        public async  Task<IActionResult> GetById(Guid id) => Ok(await _userService.GetAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateRequestDto model)
        {
            await _userService.UpdateAsync(id, model);
            return Ok(new { message = "User updated successfully" });
        }

        [HttpDelete("{id}")]
        public async  Task<IActionResult> Delete(Guid id)
        {
            await  _userService.DeleteAsync(id);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
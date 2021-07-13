using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HandlerExchange.Core.DTO;
using HandlerExchange.Core.Entities;

namespace HandlerExchange.Core.Services.WebApi.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponseDto> AuthenticateAsync(AuthenticateRequestDto dto);
        Task<IEnumerable<User>> BrowseAsync();
        Task<User> GetAsync(Guid id);
        Task  RegisterAsync(RegisterRequestDto model);
        Task  UpdateAsync(Guid id, UpdateRequestDto model);
        Task  DeleteAsync(Guid id);
    }
}
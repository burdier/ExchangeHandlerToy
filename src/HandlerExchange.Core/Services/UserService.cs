using System;
using System.Threading.Tasks;
using HandlerExchange.Core.Authorization;
using HandlerExchange.Core.DAL.Repositories;
using HandlerExchange.Core.DTO;
using HandlerExchange.Core.Entities;
using HandlerExchange.Shared;
using Mapster;
using Mapster.Utils;

namespace HandlerExchange.Core.Services
{ using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountService _accountService;
        private IJwtUtils _jwtUtils;

        public UserService(
            IUserRepository userRepository,
            IJwtUtils jwtUtils,
            IAccountService accountService
             
            )
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
            _accountService = accountService;
        }

        public async Task<AuthenticateResponseDto> AuthenticateAsync(AuthenticateRequestDto dto)
        {
            var user = await  _userRepository.GetUserByNameAsync(dto.Username);

            // validate
            if (user == null || !BCryptNet.Verify(dto.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect");

            // authentication successful
            var response = user.Adapt<AuthenticateResponseDto>();
            response.JwtToken = _jwtUtils.GenerateToken(user);
            return response;
        }
        public async Task<IEnumerable<User>> BrowseAsync()
        {
            return await _userRepository.BrowseAsync();
        }

        public async  Task<User> GetAsync(Guid id)
        {
            return await  GetUser(id);
        }

        public async Task RegisterAsync(RegisterRequestDto dto)
        {
            var anyUser = await _userRepository.GetUserByNameAsync(dto.Username);
            if (anyUser  is {}) 
                throw new AppException("Username '" + dto.Username + "' is already taken");

            var user = dto.Adapt<User>();

            user.PasswordHash = BCryptNet.HashPassword(dto.Password);
             
            await _userRepository.AddAsync(user);
            await _accountService.CreateAsync(new Account() {UserId = user.Id});
        }

        public async Task UpdateAsync(Guid id, UpdateRequestDto dto)
        {
            var user = await  GetUser(id);

            if (dto.Username != user.Username && await _userRepository.AnyWithNameAsync(dto.Username))
                throw new AppException("Username '" + dto.Username + "' is already taken");

            if (!string.IsNullOrEmpty(dto.Password))
                user.PasswordHash = BCryptNet.HashPassword(dto.Password);

            dto.Adapt(user);
            await  _userRepository.UpdateAsync(id, user);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await GetUser(id);
            await  _userRepository.DeleteAsync(id);
        }
        
        private async Task<User> GetUser(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            if (user is not {}) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}
}
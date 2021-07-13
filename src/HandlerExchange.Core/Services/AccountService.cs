using System;
using System.Threading.Tasks;
using HandlerExchange.Core.DAL.Repositories;
using HandlerExchange.Core.Entities;
using HandlerExchange.Shared;
using Microsoft.AspNetCore.Http;

namespace HandlerExchange.Core.Services
{
    class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly User _user;
        public  AccountService(IAccountRepository accountRepository, IHttpContextAccessor httpContextAccessor)
        {
            _accountRepository = accountRepository;
            _user = (User) httpContextAccessor.HttpContext?.Items["User"];
        }

        public async Task CreateAsync(Account account)
        {
            await   _accountRepository.CreateAsync(account);
        }

        public async Task Withdrawal(decimal amount)
        {
            var isPositive = amount > 0;
            var account = await _accountRepository.GetAsync(_user.Id);
            if(account is not {}) throw new AccountNotFoundException("Account can not be found",_user.Id);
            switch (isPositive)
            {
                case true:
                {
                    account.Amount += amount;
                    break;
                }
                case false:
                {
                    if (account.Amount < amount) throw new AppException($"insufficient balance");
                    account.Amount -= amount;
                    break;
                }
            }
        }

        public Task<decimal> GetAmount()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> HasBalance()
        {
            throw new System.NotImplementedException();
        }

    }
}
using System;
using System.Threading.Tasks;
using HandlerExchange.Core.Entities;

namespace HandlerExchange.Core.DAL.Repositories
{
    public interface IAccountRepository
    {
        Task CreateAsync(Account account);
        Task<Account> GetAsync(Guid id);
        Task UpdateAsync(Guid id, Account account);
    }
}
using System.Collections;
using System.Threading.Tasks;
using HandlerExchange.Core.Entities;

namespace HandlerExchange.Core.Services
{
    public interface IAccountService
    {
        Task CreateAsync(Account account);
        Task Withdrawal(decimal amount);
        Task<decimal> GetAmount();
        Task<bool> HasBalance();
    }
}
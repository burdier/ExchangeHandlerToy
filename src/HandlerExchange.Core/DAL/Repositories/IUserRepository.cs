using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HandlerExchange.Core.Entities;

namespace HandlerExchange.Core.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> BrowseAsync();
        Task<User> GetAsync(Guid id);
        Task AddAsync(User user);
        Task UpdateAsync(Guid id, User user);
        Task DeleteAsync(Guid id);
        Task<User> GetUserByNameAsync(string name);
        Task<bool> AnyWithNameAsync(string name);
    }
}
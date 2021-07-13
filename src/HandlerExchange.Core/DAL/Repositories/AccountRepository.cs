using System;
using System.Threading.Tasks;
using HandlerExchange.Core.Entities;
using HandlerExchange.Shared.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HandlerExchange.Core.DAL.Repositories
{
    public  class AccountRepository : IAccountRepository
    {
        private readonly IMongoCollection<Account> _accountCollection;
        public AccountRepository(IOptions<AppSettings> appSetting)
        {
            var client = new MongoClient(appSetting.Value.Server);
            var database = client.GetDatabase(appSetting.Value.DataBase);
            _accountCollection = database.GetCollection<Account>(nameof(Account)); 
        }

        public async Task CreateAsync(Account account)
        {
           await  _accountCollection.InsertOneAsync(account); 
        }

        public async Task<Account> GetAsync(Guid id)
        {
          var account = await  _accountCollection.FindAsync(p => p.Id == id && p.UserId == id);
          return account.FirstOrDefault();
        }

        public async Task UpdateAsync(Guid id, Account account)
        {
            await  _accountCollection.ReplaceOneAsync(p => p.Id == id, account);
        }
    }
}
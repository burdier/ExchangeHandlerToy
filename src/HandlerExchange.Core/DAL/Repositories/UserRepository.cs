using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using HandlerExchange.Core.Entities;
using HandlerExchange.Shared.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HandlerExchange.Core.DAL.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;
        private readonly AppSettings _appSetting;
        public UserRepository(IOptions<AppSettings> appSetting)
        {
            _appSetting = appSetting.Value;
            var client = new MongoClient(_appSetting.Server);
            var database = client.GetDatabase(_appSetting.DataBase);
            _userCollection = database.GetCollection<User>(nameof(User)); 
        }


        public async Task<IEnumerable<User>> BrowseAsync()
        {
           var users = await _userCollection.FindAsync(user => true);
           return users.ToList();
        }

        public async Task<User> GetAsync(Guid id)
        {
           var user = await  _userCollection.FindAsync(p => p.Id == id);
           return user.FirstOrDefault();
        }

        public async Task AddAsync(User user)
        {
            await _userCollection.InsertOneAsync(user);
        }

        public async Task UpdateAsync(Guid id, User user)
        {
            await  _userCollection.ReplaceOneAsync(p => p.Id == id,user);
        }

        public async Task DeleteAsync(Guid id)
        {
            await  _userCollection.FindOneAndDeleteAsync(p => p.Id == id);
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            var user = await  _userCollection.FindAsync(p => p.Username == name);
            return await  user.FirstOrDefaultAsync();
        }

        public async  Task<bool> AnyWithNameAsync(string userName)
        {
            var user = await _userCollection.FindAsync(p => p.Username == userName);
            return user.FirstOrDefault() is { };
        }
    }
}
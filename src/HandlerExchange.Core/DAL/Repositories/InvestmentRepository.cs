using System;
using System.Threading.Tasks;
using HandlerExchange.Core.Entities;
using HandlerExchange.Shared;
using HandlerExchange.Shared.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HandlerExchange.Core.DAL.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly IMongoCollection<Investment> _investmentCollection;
        public InvestmentRepository(IOptions<AppSettings> appSetting)
        {
            var client = new MongoClient(appSetting.Value.Server);
            var database = client.GetDatabase(appSetting.Value.DataBase);
            _investmentCollection = database.GetCollection<Investment>(nameof(Investment)); 
        }
        public async Task<Investment> findBySymbol(string symbol)
        {
            var investment = await  _investmentCollection.FindAsync(p => p.Symbol == symbol);
            return investment.FirstOrDefault();
        }
        public  async  Task Add(Investment investment)
        {
             await _investmentCollection.InsertOneAsync(investment);
        }

        public async Task<Investment> GetAsync(Guid id)
        {
            var investment = await _investmentCollection.FindAsync(p => p.Id == id);
            if(investment is not {}) throw new AppException();
            return investment.FirstOrDefault(); 
        }
    }
}
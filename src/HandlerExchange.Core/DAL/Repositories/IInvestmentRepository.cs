using System;
using System.Threading.Tasks;
using HandlerExchange.Core.Entities;

namespace HandlerExchange.Core.DAL.Repositories
{
    internal interface IInvestmentRepository
    {
        Task<Investment> findBySymbol(string name);
        Task Add(Investment investment);
        Task<Investment> GetAsync(Guid id);
    }
}
using System;
using System.Threading.Tasks;
using HandlerExchange.Core.DTO.Investment;
using HandlerExchange.Core.Entities;
using HandlerExchange.Shared.Enums;

namespace HandlerExchange.Core.Services
{
    public interface IInvestmentService
    {
        Task Add(RequestInvestmentDto requestInvestmentDto);
        Task<Investment> GetAsync(Guid id);
        Task Sell(Guid investmentId,decimal quantity);
        Task Buy(Guid investmentId, decimal quantity);
    }
}
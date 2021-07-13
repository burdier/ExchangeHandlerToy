using System;
using System.Threading.Tasks;
using HandlerExchange.Core.DAL.Repositories;
using HandlerExchange.Core.DTO.Investment;
using HandlerExchange.Core.Entities;
using HandlerExchange.Infra;
using HandlerExchange.Infra.HttpServices;
using HandlerExchange.Shared;

namespace HandlerExchange.Core.Services
{
    internal class InvestmentService : IInvestmentService
    {
        private readonly IAccountService _accountService;
        private IMarketApiService _marketApiService;
        private IInvestmentRepository _investmentRepository;

        public InvestmentService
            (
                IAccountService accountService,
                IMarketApiService marketApiService,
                IInvestmentRepository investmentRepository
            )
            {
            _accountService = accountService;
            _marketApiService = marketApiService;
            _investmentRepository = investmentRepository;
            }

        public async Task Add(RequestInvestmentDto dto) {
            dto.Id = Guid.NewGuid();
            var coin = await _marketApiService.Seek(dto.Symbol, dto.InvestmentType);
            if (coin is not { }) throw new AppException($"{dto.InvestmentType.ToString()} does not exitst");
            if (await _investmentRepository.findBySymbol(dto.Symbol) is { })
                throw new AppException($"{dto.Symbol} investment already exists");
                
            await _investmentRepository.Add(new Investment()
            {
                Id = dto.Id,
                Name =  coin.Name,
                Symbol = dto.Symbol,
            });
        }
        public async Task Sell(Guid investmentId, decimal quantity)
        {
            throw new NotImplementedException();
        }

        public async Task Buy(Guid investmentId, decimal ammount)
        {
            var investment = await _investmentRepository.GetAsync(investmentId);
            if(investment is not {}) throw new AppException($"Investment can not be found"); 
            var coinPrice =  _marketApiService.GetPriceAsync("");
              
        }

        public Task<Investment> GetAsync(Guid id)=>_investmentRepository.GetAsync(id);
    }
}
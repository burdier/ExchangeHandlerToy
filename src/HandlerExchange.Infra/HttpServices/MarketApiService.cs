using System.Net.Http;
using System.Threading.Tasks;
using HandlerExchange.Infra.POCOs;
using HandlerExchange.Shared.Enums;

namespace HandlerExchange.Infra.HttpServices
{
     internal class MarketApiService : IMarketApiService
     {
         private readonly CryptoService _cryptoService;
         public MarketApiService(CryptoService cryptoService)
         {
             _cryptoService = cryptoService;
         }

        public decimal GetPriceAsync(string symbol)
        {
            throw new System.NotImplementedException();
        }

        public async Task<CoinMarket> Seek(string symbol, InvestmentType investmentType)
         {
             return await  _cryptoService.Seek(symbol);
         }
    }
}
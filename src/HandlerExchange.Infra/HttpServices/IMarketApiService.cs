using System.Threading.Tasks;
using HandlerExchange.Infra.POCOs;
using HandlerExchange.Shared.Enums;

namespace HandlerExchange.Infra.HttpServices
{
    public interface IMarketApiService
    {
        Task<CoinMarket> Seek(string name, InvestmentType investmentType);
        decimal GetPriceAsync(string symbol);
    }
}
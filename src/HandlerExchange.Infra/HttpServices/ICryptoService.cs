using System.Threading.Tasks;
using HandlerExchange.Infra.POCOs;
using HandlerExchange.Shared.Enums;

namespace HandlerExchange.Infra.HttpServices
{
    public interface ICryptoService
    {
        Task<CoinMarket> Seek(string symbol);
        Task<CoinMarket> GetPriceAsync(string symbol);
    }
}
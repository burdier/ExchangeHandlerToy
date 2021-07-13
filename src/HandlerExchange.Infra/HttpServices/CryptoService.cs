using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HandlerExchange.Infra.POCOs;

namespace HandlerExchange.Infra.HttpServices
{
    public  class CryptoService
    {
        private HttpClient Client {get;set;}
        public CryptoService(HttpClient client)
        {
            Client = client;
        }
        public async Task<CoinMarket> Seek(string symbol)
        {
            var crypto = await Client.GetFromJsonAsync<CoinMarketCapResponse>($"v1/cryptocurrency/map?symbol={symbol}");
            return new CoinMarket() {Name = crypto.Data[0].Name, Symbol = crypto.Data[0].Symbol};
        }

        public async Task<CoinMarket> GetPriceAsync(string symbol)
        {
            throw new NotImplementedException();
            var crypto = await Client.GetFromJsonAsync<CoinMarketCapResponse>($"v1/cryptocurrency/map?symbol={symbol}");
        }
}
}
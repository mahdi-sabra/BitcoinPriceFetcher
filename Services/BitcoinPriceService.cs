using BitcoinPriceFetcher.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BitcoinPriceFetcher.Services
{
    public class BitstampPriceService : IBitcoinPriceService
    {
        private readonly HttpClient _httpClient;

        public BitstampPriceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BitcoinPrice> FetchBitcoinPriceAsync()
        {
            var response = await _httpClient.GetStringAsync("https://www.bitstamp.net/api/v2/ticker/btcusd/");
            var data = JsonSerializer.Deserialize<BitstampResponse>(response);
            return new BitcoinPrice
            {
                Source = "Bitstamp",
                Price = Math.Round(Convert.ToDecimal(data.last),2),
                Timestamp = DateTime.UtcNow
            };
        }

        private class BitstampResponse
        {
            public string timestamp { get; set; }
            public string open {get; set; }
            public string high { get; set; }
            public string low { get; set; }
            public string last { get; set; }
            public string volume { get; set; }
            public string vwap { get; set; }
            public string bid { get; set; }
            public string ask { get; set; }
            public string side { get; set; }
            public string open_24 { get; set; }
            public string percent_change_24 { get; set; }

        }
    }

    public class BitfinexPriceService : IBitcoinPriceService
    {
        private readonly HttpClient _httpClient;

        public BitfinexPriceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BitcoinPrice> FetchBitcoinPriceAsync()
        {
            var response = await _httpClient.GetStringAsync("https://api.bitfinex.com/v1/pubticker/BTCUSD");
            var data = JsonSerializer.Deserialize<BitfinexResponse>(response); 
                return new BitcoinPrice
            {
                Source = "Bitfinex",
                Price = Math.Round(Convert.ToDecimal(data.last_price),2),
                Timestamp = DateTime.UtcNow
            };
        }

        private class BitfinexResponse
        {
           // [JsonPropertyName("last_price")]
            public string last_price { get; set; }
            public string mid { get;set; }
            public string bid { get; set; }
            public string ask { get; set; }
            public string low { get; set; }
            public string high { get; set; }
            public string volume { get; set; }
            public string timestamp { get; set; }

        }
    }
}

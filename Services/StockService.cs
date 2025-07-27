using FinanceAnalyzer.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace FinanceAnalyzer.Services
{
    public class StockService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;

        public StockService(HttpClient client, string baseUrl)
        {
            _client = client;
            _baseUrl = baseUrl;
        }

        public async Task<List<StockData>> GetTopFallingStocks(List<string> tickers, int days = 5)
        {
            var stocks = new List<StockData>();

            foreach (var ticker in tickers)
            {
                try
                {
                    var url = $"{_baseUrl}/quote/{ticker}?range={days}d&interval=1d";
                    var response = await _client.GetStringAsync(url);
                    using var doc = JsonDocument.Parse(response);
                    var result = doc.RootElement.GetProperty("results")[0];

                    var changePercent = result.GetProperty("regularMarketChangePercent").GetDouble();
                    var price = result.GetProperty("regularMarketPrice").GetDouble();

                    stocks.Add(new StockData
                    {
                        Ticker = ticker,
                        ClosePrice = price,
                        ChangePercent = changePercent
                    });
                }
                catch
                {
                    // Ignora tickers que falharem na API
                }
            }

            return stocks.OrderBy(s => s.ChangePercent).Take(20).ToList();
        }
    }
}

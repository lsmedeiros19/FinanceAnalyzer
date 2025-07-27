using FinanceAnalyzer.Services;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var apiUrl = config["Brapi:BaseUrl"];
var tickers = config.GetSection("Brapi:Tickers").Get<List<string>>();

var httpClient = new HttpClient();
var stockService = new StockService(httpClient, apiUrl);
var reportService = new ReportService();

Console.WriteLine("🔍 Buscando maiores quedas do mercado...");

var stocks = await stockService.GetTopFallingStocks(tickers);
reportService.GenerateCsvReport(stocks, "Top20Quedas.csv");

Console.WriteLine("✅ Relatório gerado: Top20Quedas.csv");

using FinanceAnalyzer.Models;
using FinanceAnalyzer.Utils;

namespace FinanceAnalyzer.Services
{
    public class ReportService
    {
        public void GenerateCsvReport(List<StockData> stocks, string filePath)
        {
            CsvHelper.WriteCsv(stocks, filePath);
        }
    }
}

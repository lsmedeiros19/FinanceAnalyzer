using FinanceAnalyzer.Models;
using System.Globalization;

namespace FinanceAnalyzer.Utils
{
    public static class CsvHelper
    {
        public static void WriteCsv(List<StockData> stocks, string filePath)
        {
            using var writer = new StreamWriter(filePath);
            writer.WriteLine("Ticker,ClosePrice,ChangePercent");

            foreach (var s in stocks)
            {
                writer.WriteLine($"{s.Ticker},{s.ClosePrice.ToString(CultureInfo.InvariantCulture)},{s.ChangePercent.ToString(CultureInfo.InvariantCulture)}");
            }
        }
    }
}

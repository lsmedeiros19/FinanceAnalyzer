namespace FinanceAnalyzer.Models
{
    public class StockData
    {
        public string Ticker { get; set; }
        public double ClosePrice { get; set; }
        public double ChangePercent { get; set; }
    }
}

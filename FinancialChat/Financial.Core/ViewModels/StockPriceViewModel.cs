namespace Financial.Core.ViewModels
{
    public class StockPriceViewModel
    {
        public string Symbol { get; set; }

        public decimal Close { get; set; }

        public static implicit operator string(StockPriceViewModel stock) => $"{stock.Symbol} quote is ${stock.Close:N2} per share";
    }
}

namespace Proyecto_2_3101.Models.ViewModels;

public class RevenueReportViewModel
{
    public List<DailyRevenueItem> DailyRevenueTotals { get; set; } = new();
    public IEnumerable<PaymentModel>? DetailedPayments { get; set; }
    public decimal TotalRevenueCollected => DailyRevenueTotals.Sum(x => x.TotalAmount);

}

public class DailyRevenueItem
{
    public DateTime CalendarDate { get; set; }
    public int TotalTransactions { get; set; }
    public decimal TotalAmount { get; set; }
}
using Proyecto_2_3101.Models.Enums;

namespace Proyecto_2_3101.Models.ViewModels;

public class OrderStatusReportViewModel
{
    public List<StatusCountItem> StatusBreakdown { get; set; } = new();
    public int TotalOrdersCount { get; set; }
    public decimal GrandTotalPrice { get; set; }
}

public class StatusCountItem
{
    public OrderStatus Status { get; set; }
    public int Count { get; set; }
    public decimal TotalRevenue { get; set; }
}
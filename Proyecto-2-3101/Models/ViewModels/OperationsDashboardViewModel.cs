using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Models.ViewModels
{
    public class OperationsDashboardViewModel
    {
        // 1. Core transactional lists for today
        public List<OrderModel> TodayOrdersList { get; set; } = new();

        // 2. High-level metric counts computed from the dataset
        public int TotalOrdersToday => TodayOrdersList.Count;
        public int PendingCount { get; set; }
        public int ProcessingCount { get; set; }
        public int CompletedCount { get; set; }
        
        // Live financial indicator accumulation metric
        public decimal TotalRevenueToday { get; set; }
    }
}
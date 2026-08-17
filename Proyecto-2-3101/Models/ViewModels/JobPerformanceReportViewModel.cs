namespace Proyecto_2_3101.Models.ViewModels
{
    public class JobPerformanceReportViewModel
    {
        // 1. Holds the detailed statistics for every single service type
        public List<JobPerformanceItem> JobStatistics { get; set; } = new();

        // 2. High-level metric tracking to identify the #1 top-performing item
        public JobPerformanceItem? MostRequestedJob => JobStatistics.OrderByDescending(x => x.RequestCount).FirstOrDefault();

        public int GrandTotalServicesRendered => JobStatistics.Sum(x => x.RequestCount);
        public decimal GrandTotalRevenueGenerated => JobStatistics.Sum(x => x.RevenueGenerated);
    }

    public class JobPerformanceItem
    {
        public int JobTypeId { get; set; }
        public string JobTypeName { get; set; } = string.Empty;
        public int RequestCount { get; set; }
        public decimal RevenueGenerated { get; set; }
    }
}
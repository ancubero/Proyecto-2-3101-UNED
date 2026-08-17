using Microsoft.EntityFrameworkCore;
using Proyecto_2_3101.Data;
using Proyecto_2_3101.Models.ViewModels;

namespace Proyecto_2_3101.Repositories;

public class JobOrdersRepository(DataBaseContext context) : IJobOrdersRepository
{
    public async Task<JobPerformanceReportViewModel> GetJobPerformanceReportAsync()
    {
        var aggregatedData = await context.JobOrders
            .Include(jo => jo.JobType)
            .GroupBy(jo => new { jo.JobTypeId, jo.JobType.Name })
            .Select(g => new JobPerformanceItem
            {
                JobTypeId = g.Key.JobTypeId,
                JobTypeName = g.Key.Name,
                RequestCount = g.Count(), 
                RevenueGenerated = g.Sum(jo => jo.Price) 
            })
            .OrderByDescending(item => item.RequestCount) 
            .ToListAsync();
        
        return new JobPerformanceReportViewModel
        {
            JobStatistics = aggregatedData
        };
    }
}
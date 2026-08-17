using Proyecto_2_3101.Models.ViewModels;
using Proyecto_2_3101.Repositories;

namespace Proyecto_2_3101.Services;

public class JobOrdersService(IJobOrdersRepository jobOrdersRepository) : IJobOrdersService
{
    public async Task<JobPerformanceReportViewModel> GetJobPerformanceReportAsync()
    {
        return await jobOrdersRepository.GetJobPerformanceReportAsync();
    }
}
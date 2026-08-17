using Proyecto_2_3101.Models.ViewModels;

namespace Proyecto_2_3101.Services;

public interface IJobOrdersService
{
    Task<JobPerformanceReportViewModel> GetJobPerformanceReportAsync();
}
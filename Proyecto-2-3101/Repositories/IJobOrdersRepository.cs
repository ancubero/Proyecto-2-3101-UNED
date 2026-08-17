using Proyecto_2_3101.Models.ViewModels;

namespace Proyecto_2_3101.Repositories;

public interface IJobOrdersRepository
{
    Task<JobPerformanceReportViewModel> GetJobPerformanceReportAsync();
}
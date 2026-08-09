using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Services;

public interface IJobTypeService
{
    Task AddAsync(JobTypeModel jobType, int userId);
    Task UpdateAsync(JobTypeModel jobType, int userId);
    Task<IEnumerable<JobTypeModel>> GetAllAsync();
    Task<IEnumerable<JobTypeModel>> GetAllByActiveAsync(bool active);
    Task<JobTypeModel?> GetByIdAsync(int id);
}
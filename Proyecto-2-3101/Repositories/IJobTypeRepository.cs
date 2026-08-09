using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Repositories;

public interface IJobTypeRepository
{
    Task AddAsync(JobTypeModel jobTypeModel);
    Task UpdateAsync(JobTypeModel jobTypeModel);
    Task<IEnumerable<JobTypeModel>> GetAllAsync();
    Task<IEnumerable<JobTypeModel>> GetAllByActiveAsync(bool active);
    Task<JobTypeModel?> GetByIdAsync(int id);
    
}
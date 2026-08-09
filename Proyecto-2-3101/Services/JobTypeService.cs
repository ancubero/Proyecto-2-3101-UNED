using Proyecto_2_3101.Models;
using Proyecto_2_3101.Repositories;

namespace Proyecto_2_3101.Services;

public class JobTypeService(IJobTypeRepository jobTypeRepository) : IJobTypeService
{
    public async Task AddAsync(JobTypeModel jobType, int userId)
    {
        jobType.CreatedByUserId = userId;
        jobType.CreatedAt = DateTimeOffset.Now;
        await jobTypeRepository.AddAsync(jobType);
    }

    public async Task UpdateAsync(JobTypeModel jobType, int userId)
    {
        jobType.UpdatedByUserId = userId;
        jobType.UpdatedAt = DateTimeOffset.Now;
        await jobTypeRepository.UpdateAsync(jobType);
    }

    public async Task<IEnumerable<JobTypeModel>> GetAllAsync()
    {
        return await jobTypeRepository.GetAllAsync();
    }

    public async Task<IEnumerable<JobTypeModel>> GetAllByActiveAsync(bool active)
    {
        return await jobTypeRepository.GetAllByActiveAsync(active);
    }

    public async Task<JobTypeModel?> GetByIdAsync(int id)
    {
        return await jobTypeRepository.GetByIdAsync(id);
    }
}
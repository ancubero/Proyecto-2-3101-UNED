using Microsoft.EntityFrameworkCore;
using Proyecto_2_3101.Data;
using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Repositories;

public class JobTypeRepository(DataBaseContext context) : IJobTypeRepository
{
    public async Task AddAsync(JobTypeModel jobTypeModel)
    {
        await context.JobTypes.AddAsync(jobTypeModel);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(JobTypeModel jobTypeModel)
    {
        context.JobTypes.Update(jobTypeModel);
        context.Entry(jobTypeModel).Property(x => x.CreatedAt).IsModified = false;
        context.Entry(jobTypeModel).Property(x => x.CreatedByUserId).IsModified = false;
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<JobTypeModel>> GetAllAsync()
    {
        return await context.JobTypes.ToListAsync();
    }

    public async Task<IEnumerable<JobTypeModel>> GetAllByActiveAsync(bool active)
    {
        return await context.JobTypes.Where(x => x.IsActive == active).ToListAsync();
    }

    public async Task<JobTypeModel?> GetByIdAsync(int id)
    {
        return await context.JobTypes.FindAsync(id);
    }
}
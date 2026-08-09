using Microsoft.EntityFrameworkCore.Storage;

namespace Proyecto_2_3101.Data;


public class UnitOfWork(DataBaseContext context) : IUnitOfWork
{
    public void Dispose() => context.Dispose();

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await context.Database.BeginTransactionAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}
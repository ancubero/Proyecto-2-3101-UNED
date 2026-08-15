using Microsoft.EntityFrameworkCore.Storage;

namespace Proyecto_2_3101.Data;


public class UnitOfWork(DataBaseContext context) : IUnitOfWork
{
    
    private IDbContextTransaction? _currentTransaction;
    
    public void Dispose() => context.Dispose();

    public async Task BeginTransactionAsync()
    {
       _currentTransaction = await context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.CommitAsync();
            }
        }
        finally
        {
            await DisposeTransactionAsync();
        }
    }

    public async Task RollbackTransactionAsync()
    {
        try
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.RollbackAsync();
            }
        }
        finally
        {
            await DisposeTransactionAsync();
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
    
    private async Task DisposeTransactionAsync()
    {
        if (_currentTransaction != null)
        {
            await _currentTransaction.DisposeAsync();
            _currentTransaction = null;
        }
    }
}
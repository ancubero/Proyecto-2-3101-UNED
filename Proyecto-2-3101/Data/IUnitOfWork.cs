using Microsoft.EntityFrameworkCore.Storage;

namespace Proyecto_2_3101.Data;

public interface IUnitOfWork : IDisposable
{
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task<int> SaveChangesAsync();
}
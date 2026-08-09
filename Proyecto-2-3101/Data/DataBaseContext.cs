using Microsoft.EntityFrameworkCore;
using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Data;

public class DataBaseContext(DbContextOptions<DataBaseContext> options) : DbContext(options)
{

    public DbSet<UserModel> Users { get; set; }
    public DbSet<ClientModel> Clients { get; set; }
    public DbSet<VehicleModel> Vehicles { get; set; }
    public DbSet<JobTypeModel> JobTypes { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.UserIndexes();
        modelBuilder.ClientsIndexes();
        modelBuilder.SeedUsers();
        modelBuilder.CreatedByForeignKeyIndexes();
        modelBuilder.ModifiedByForeignKeyIndexes();
        modelBuilder.PricePrecision();
    }
    
    
}
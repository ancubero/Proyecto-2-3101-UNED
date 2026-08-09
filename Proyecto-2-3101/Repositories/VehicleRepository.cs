using Microsoft.EntityFrameworkCore;
using Proyecto_2_3101.Data;
using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Repositories;

public class VehicleRepository(DataBaseContext context) : IVehicleRepository
{
    public async Task<IEnumerable<VehicleModel>> GetVehiclesAsync(int clientId)
    {
        return await context.Vehicles.Where(x => x.ClientId == clientId).ToListAsync();
    }

    public async Task<VehicleModel?> GetVehicleAsync(int id)
    {
        return await context.Vehicles.FindAsync(id);
    }

    public async Task<VehicleModel?> GetVehicleAsync(string plateNumber)
    {
        return await context.Vehicles
            .Include(x => x.Client)
            .Where(x => x.PlateNumber == plateNumber).FirstOrDefaultAsync();
    }

    public async Task CreateVehicleAsync(VehicleModel vehicle)
    {
        await context.Vehicles.AddAsync(vehicle);
        await context.SaveChangesAsync();
    }

    public async Task UpdateVehicleAsync(VehicleModel vehicle)
    {
        context.Vehicles.Update(vehicle);
        context.Entry(vehicle).Property(x => x.ClientId).IsModified = false;
        context.Entry(vehicle).Property(x => x.CreatedAt).IsModified = false;
        context.Entry(vehicle).Property(x => x.CreatedByUserId).IsModified = false;
        await context.SaveChangesAsync();
        
    }

    public async Task<bool> IsVehicleExistAsync(string plateNumber)
    {
        return await context.Vehicles.AnyAsync(x => x.PlateNumber == plateNumber);
    }
}
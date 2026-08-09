using Proyecto_2_3101.Models;
using Proyecto_2_3101.Repositories;

namespace Proyecto_2_3101.Services;

public class VehicleService(IVehicleRepository repository) : IVehicleService
{
    public async Task<IEnumerable<VehicleModel>> GetVehiclesAsync(int clientId)
    {
        return await repository.GetVehiclesAsync(clientId);
    }

    public async Task<VehicleModel?> GetVehicleAsync(int id)
    {
        return await repository.GetVehicleAsync(id);
    }

    public async Task<VehicleModel?> GetVehicleAsync(string plateNumber)
    {
        return await repository.GetVehicleAsync(plateNumber);
    }

    public async Task CreateVehicleAsync(VehicleModel vehicle, int userId, int clientId)
    {
        
        var isVehicleExist = await repository.IsVehicleExistAsync(vehicle.PlateNumber);
        
        if(isVehicleExist) throw new Exception($"El vehiculo con la placa {vehicle.PlateNumber} ya se encuentra registrado");

        vehicle.ClientId = clientId;
        vehicle.CreatedByUserId = userId;
        vehicle.CreatedAt = DateTimeOffset.Now;
        
        await repository.CreateVehicleAsync(vehicle);
    }

    public async Task UpdateVehicleAsync(VehicleModel vehicle, int userId)
    {
        vehicle.UpdatedByUserId = userId;
        vehicle.UpdatedAt = DateTimeOffset.Now;
        
        await repository.UpdateVehicleAsync(vehicle);
    }
}
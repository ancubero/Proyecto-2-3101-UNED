using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Repositories;

public interface IVehicleRepository
{
    Task<IEnumerable<VehicleModel>> GetVehiclesAsync(int clientId);
    Task<VehicleModel?> GetVehicleAsync(int id);
    Task<VehicleModel?> GetVehicleAsync(string plateNumber);
    Task CreateVehicleAsync(VehicleModel vehicle);
    Task UpdateVehicleAsync(VehicleModel vehicle);
    Task<bool> IsVehicleExistAsync(string plateNumber);
}